using Common.Utility.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using static Common.Enum.Enum;

namespace Common.Utility.Core
{
    public class ExpressionFilter : IExpressionFilter
    {
        private readonly static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private readonly static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private readonly static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });

        /*private readonly ILoggingService _loggingService;
        public ExpressionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }*/

        public ExpressionFilter()
        {
        }

        /// <summary>
        /// evaluates search criteria from string
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private List<FilterQuery> EvaluateFiltersFromString(string predicate)
        {
            string patternnew = @"(\p{P}?)([\w-.]+?)(:|!|>|<|~)(\p{P}?)([\w-. ]+?)(\p{P}?),";
            MatchCollection matches = Regex.Matches(predicate + ",", patternnew);
            List<FilterQuery> filters = new List<FilterQuery>();
            foreach (Match match in matches)
            {
                filters.Add(BuildFilterQuery(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value, match.Groups[6].Value));
            }
            return filters;
        }

        /// <summary>
        /// Builds the filter query based on search string
        /// </summary>
        /// <param name="condition">or, and</param>
        /// <param name="propertyName">property name</param>
        /// <param name="operation">operation type</param>
        /// <param name="prefix">prefix for starts with</param>
        /// <param name="propertyValue"> property value</param>
        /// <param name="suffix">suffix for ends with</param>
        /// <returns></returns>
        private FilterQuery BuildFilterQuery(string condition, string propertyName, string operation, string prefix, string propertyValue, string suffix)
        {
            if (prefix == "-")
            {
                propertyValue = string.Concat(prefix, propertyValue);
            }
            FilterQuery filters = new FilterQuery()
            {
                OperatorType = (condition == "'") ? OperatorType.Or : OperatorType.And,
                PropertyName = propertyName,
                PropertyValue = propertyValue,
                FilterType = GetFilterType(operation),
            };
            if (prefix == "*" && suffix == "*")
            {
                filters.FilterType = FilterType.Contains;
            }
            else if (prefix == "*")
            {
                filters.FilterType = FilterType.EndsWith;
            }
            else if (suffix == "*")
            {
                filters.FilterType = FilterType.StartsWith;
            }

            return filters;
        }


        /// <summary>
        /// Converts the value to Type specific
        /// </summary>
        /// <param name="member">Member</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        private UnaryExpression ConvertValueToType(MemberExpression member, object value)
        {
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);
            var propertyValue = converter.ConvertFrom(value);
            var constant = Expression.Constant(propertyValue);
            return Expression.Convert(constant, propertyType);
        }

        /// <summary>
        /// Get operator for value matching
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <returns></returns>
        private FilterType GetFilterType(string filterType)
        {
            FilterType filter = FilterType.Equal;
            switch (filterType)
            {
                case ":":
                    filter = FilterType.Equal;
                    break;
                case "!":
                    filter = FilterType.NotEqual;
                    break;
                case "<":
                    filter = FilterType.LessThan;
                    break;
                case ">":
                    filter = FilterType.GreaterThan;
                    break;
                case "~":
                    filter = FilterType.Range;
                    break;
            }
            return filter;
        }

        /// <summary>
        /// Build Expression for dynamic filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FilterExpression"></param>
        /// <returns></returns>
        public Expression<Func<T, bool>> GetExpression<T>(string FilterExpression, out bool isValid)
        {
            isValid = true;
            Expression exp = null;
            try
            {
                List<FilterQuery> filters = EvaluateFiltersFromString(FilterExpression);

                if (filters == null)
                    return null;
                ParameterExpression param = Expression.Parameter(typeof(T), "t");

                foreach (FilterQuery filter in filters)
                {
                    if (exp == null)
                        exp = GetExpression(param, filter);
                    else if (filter.OperatorType == OperatorType.Or)
                        exp = Expression.Or(exp, GetExpression(param, filter));
                    else
                        exp = Expression.AndAlso(exp, GetExpression(param, filter));
                }
                return Expression.Lambda<Func<T, bool>>(exp, param);
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return null;
        }

        // public Expression GetExpression<T>(ParameterExpression param, string PropName, string value, FilterType filterType)
        /// <summary>
        /// Get Expression for filter
        /// </summary>
        /// <param name="param">Parameter Expression</param>
        /// <param name="filter">Filter criteria</param>
        /// <returns></returns>
        private Expression GetExpression(ParameterExpression param, FilterQuery filter)
        {
            MemberExpression member = null;
            if (filter.PropertyName.Split('.').Length > 1)
            {
                int index = 0;
                foreach (var value in filter.PropertyName.Split('.'))
                {
                    if (index == 0)
                    {
                        member = Expression.Property(param, value);

                    }
                    else
                    {
                        member = Expression.Property(member, value);
                    }
                    index++;

                }
            }
            else
            {
                member = Expression.Property(param, filter.PropertyName);
            }
            UnaryExpression valueExpression = null;
            if (filter.FilterType != FilterType.Range)
            {
                valueExpression = ConvertValueToType(member, filter.PropertyValue);
            }

            switch (filter.FilterType)
            {
                case FilterType.Equal:
                    return Expression.Equal(member, valueExpression);
                case FilterType.NotEqual:
                    return Expression.NotEqual(member, valueExpression);
                case FilterType.StartsWith:
                    return Expression.Call(member, startsWithMethod, valueExpression);
                case FilterType.EndsWith:
                    return Expression.Call(member, endsWithMethod, valueExpression);
                case FilterType.Contains:
                    return Expression.Call(member, containsMethod, valueExpression);
                case FilterType.GreaterThan:
                    return Expression.GreaterThan(member, valueExpression);
                case FilterType.LessThan:
                    return Expression.LessThan(member, valueExpression);
                case FilterType.Range:
                    var arrValues = filter.PropertyValue.ToString().Split('-');
                    Expression Exp = null;
                    foreach (var data in arrValues)
                    {
                        var convertedValue = ConvertValueToType(member, data);
                        if (Exp == null)
                            Exp = Expression.Equal(member, convertedValue);
                        else
                            Exp = Expression.Or(Exp, Expression.Equal(member, convertedValue));
                    }
                    return Exp;
            }

            return null;
        }

        /// <summary>
        /// creates order by clause
        /// </summary>
        /// <typeparam name="T">IQueryable object on which needs to create this order by clause</typeparam>
        /// <param name="query">Object on which need to create query</param>
        /// <param name="sortColumn">column name by which records will be sorted</param>
        /// <param name="sortOrderAsc">true-ASC,false-DESC</param>
        /// <returns>Iqueryable object with order by clause</returns>       
        public IQueryable<T> OrderByDynamic<T>(IQueryable<T> query, string sortColumn, out bool isValid, bool sortOrderAsc = true)
        {
            isValid = true;
            try
            {
                ParameterExpression parameter = Expression.Parameter(query.ElementType, "");

                MemberExpression property = Expression.Property(parameter, sortColumn);
                LambdaExpression lambda = Expression.Lambda(property, parameter);

                string methodName = sortOrderAsc ? "OrderBy" : "OrderByDescending";

                Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                      new Type[] { query.ElementType, property.Type },
                                      query.Expression, Expression.Quote(lambda));

                return query.Provider.CreateQuery<T>(methodCallExpression);

            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return default;
        }
    }
}

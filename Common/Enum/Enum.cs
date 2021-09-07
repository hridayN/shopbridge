using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enum
{
    public class Enum
    {
        public enum FilterType
        {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterThanOrEqual,
            LessThanOrEqual,
            Contains,
            StartsWith,
            EndsWith,
            Range
        }

        public enum OperatorType
        {
            Or,
            And
        }
    }
}

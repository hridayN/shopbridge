using static Common.Enum.Enum;

namespace Common.Utility
{
    /// <summary>
    /// This class used to store all filter criteria evaluated from string
    /// </summary>
    public class FilterQuery
    {

        /// <summary>
        /// Property name on which need to match the value
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Type of filter equal, notequal etc.
        /// </summary>
        public FilterType FilterType { get; set; }

        /// <summary>
        /// Value that needs to be match against a property with a specific operator
        /// </summary>
        public object PropertyValue { get; set; }

        /// <summary>
        /// whther or or and condition
        /// </summary>
        public OperatorType OperatorType { get; set; }
    }
}

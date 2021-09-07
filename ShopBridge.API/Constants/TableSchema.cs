namespace ShopBridge.API.Constants
{
    /// <summary>
    /// Constant class for Schema Names
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// Protected constructor
        /// </summary>
        protected TableSchema()
        {
        }

        /// <summary>
        /// Schema name for Product related tables
        /// </summary>
        public const string Product = "sb_product";

        /// <summary>
        /// Schema name for User related tables
        /// </summary>
        public const string User = "sb_user";
    }
}

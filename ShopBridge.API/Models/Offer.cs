using System;
using static ShopBridge.API.Enums.Enums;

namespace ShopBridge.API.Models
{
    /// <summary>
    /// Offer model
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Offer Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Offer Category
        /// </summary>
        public OfferCategory Category { get; set; }

        /// <summary>
        /// Offer DiscountPercentage
        /// </summary>
        public double DiscountPercentage { get; set; }

        /// <summary>
        /// Offer start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Offer end date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}

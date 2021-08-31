using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Enums
{
    /// <summary>
    /// Enums class
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Product category enum
        /// </summary>
        public enum ProductCategory
        {
            BodyCare = 0,
            Consumable = 1,
            Decomposable = 2,
            Baby = 3,
            Gift = 4,
            Crockery = 5,
            Electricity = 6,
            Toiletry = 7,
            Education = 8
        }

        /// <summary>
        /// OfferCategory enum
        /// </summary>
        public enum OfferCategory
        {
            BankOffer = 0,
            Cashback = 1,
            CashbackOnOtherItems = 2
        }
    }
}

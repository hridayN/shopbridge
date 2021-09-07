using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Infrastructure
{
    /// <summary>
    /// Db context class for ShopBridgeProduct
    /// </summary>
    public class ShopBridgeProductDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ShopBridgeProductDbContext(): base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ShopBridgeProductDbContext(DbContextOptions<ShopBridgeProductDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Product table
        /// </summary>
        public DbSet<ProductEntity> Product { get; set; }

        /// <summary>
        /// User table
        /// </summary>
        public DbSet<UserEntity> User { get; set; }
    }
}

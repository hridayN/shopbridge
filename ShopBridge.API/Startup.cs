using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.API.Infrastructure;
using ShopBridge.API.Infrastructure.Contracts.Base;
using ShopBridge.API.Infrastructure.Respositories;
using ShopBridge.API.Services.Contract;
using ShopBridge.API.Services.Core;
using ShopBridge.API.DBConnector;
using Microsoft.EntityFrameworkCore;

namespace ShopBridge.API
{
    public class Startup
    {
        /// <summary>
        /// Startup class
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration object
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.SetUpDataBase<ShopBridgeProductDbContext>(Configuration);
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));
            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();
            // Add Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ShopBridgeProductDbContext>();
                context.Database.Migrate();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

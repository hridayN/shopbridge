using Common.Utility.Contracts;
using Common.Utility.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopBridge.API.DBConnector;
using ShopBridge.API.Infrastructure;
using ShopBridge.API.Infrastructure.Contracts.Base;
using ShopBridge.API.Infrastructure.Respositories;
using ShopBridge.API.Services.Contract;
using ShopBridge.API.Services.Contracts;
using ShopBridge.API.Services.Core;
using System.Text;

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
            /*
             register the JWT authentication middleware by calling the method AddAuthentication
            */
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions => 
            {
                /*
                According to the configuration, the token is going to be valid if:
                The issuer is the actual server that created the token (ValidateIssuer=true)
                The receiver of the token is a valid recipient (ValidateAudience=true)
                The token has not expired (ValidateLifetime=true)
                The signing key is valid and is trusted by the server (ValidateIssuerSigningKey=true)
                */
                bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:57174",
                    ValidAudience = "http://localhost:57174",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });
            services.SetUpDataBase<ShopBridgeProductDbContext>(Configuration);
            services.AddMvc();
            services.AddControllers();
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));
            // Add Application Layer
            services.AddScoped<IExpressionFilter, ExpressionFilter>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            // Add Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddCors(options => 
            {
                options.AddPolicy("EnableCORS", builder => 
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("EnableCORS");
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ShopBridgeProductDbContext>();
                context.Database.EnsureCreated();
            }
            app.UseRouting();
            /*make our authentication middleware available to the application.*/
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

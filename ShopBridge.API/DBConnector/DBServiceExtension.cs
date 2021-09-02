using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShopBridge.API.DBConnector
{
    public static class DBServiceExtension
    {
        public static IServiceCollection SetUpDataBase<T> (this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            DataBaseOptions dataBaseOptions = new DataBaseOptions();
            configuration.Bind(DataBaseOptions.DataBase, dataBaseOptions);
            services.AddSingleton(dataBaseOptions);

            services.AddDbContext<T>(optionsBuilder =>
            {
                if (!optionsBuilder.IsConfigured && !string.IsNullOrWhiteSpace(dataBaseOptions.ConnectionString))
                {
                    switch (dataBaseOptions.Type)
                    {
                        case "PostgreSQL":
                            optionsBuilder.UseNpgsql(dataBaseOptions.ConnectionString);
                            break;
                        default:
                            optionsBuilder.UseNpgsql(dataBaseOptions.ConnectionString);
                            break;
                    }
                }
            });
            return services;
        }
    }
}

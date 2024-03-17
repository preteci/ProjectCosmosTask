using Microsoft.EntityFrameworkCore;
using DAL.Data;
using Azure.Identity;

namespace WebApi.Extensions
{
    public static class AplicationServiceExtension
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CosmosContext>(opt =>
            {
                opt.UseCosmos(config["CosmosDB:Url"], config["CosmosDB:Key"], config["CosmosDB:DatabaseName"]);
                
            });

            services.AddCors();

            return services;
        }

        public static IConfigurationManager AddAzureKeyVaultAsConfig(this IConfigurationManager manager, IConfiguration config)
        {
            var keyVaultName = config.GetValue<string>("KeyVaultName");
            var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net");
            manager.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
            return manager;
        }


    }
}

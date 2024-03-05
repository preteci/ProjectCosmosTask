using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Extensions
{
    public static class AplicationServiceExtension
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CosmosContext>(opt =>
            {
                opt.UseCosmos(config.GetConnectionString("CosmosUrl"), config.GetConnectionString("CosmosKey"), config.GetConnectionString("CosmosDatabaseName"));
            });

            services.AddCors();

            return services;
        }
    }
}

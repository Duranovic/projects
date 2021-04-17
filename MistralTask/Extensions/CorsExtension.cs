using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MistralTask.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsExtension(this IServiceCollection service, IConfiguration configuration)
        {
            var origins = configuration.GetSection("Cors:Origins").Get<string>();

            var urls = origins.Split(";");

            service.AddCors(o => o.AddPolicy("DefaultPolicy", builder =>
            {
                builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins(urls)
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            return service;
        }
    }
}

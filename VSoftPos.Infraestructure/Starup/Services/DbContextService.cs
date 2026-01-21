using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Starup.Services
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PosContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("ConnDB"));
            });

            return services;
        }
    }
}

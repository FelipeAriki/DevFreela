using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddData(configuration)
                .AddRepositories();
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            //builder.Services.AddDbContext<DevfreelaDbContext>(o => o.UseInMemoryDatabase("DevfreelaDb"));
            var connectionString = configuration.GetConnectionString("DevFreelaCs");
            services.AddDbContext<DevfreelaDbContext>(o => o.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}

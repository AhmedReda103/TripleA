

using Microsoft.Extensions.DependencyInjection;
using TripleA.Infrustructure.InfrastructureBases;
using TripleA.Infrustructure.unitOfWork;

namespace TripleA.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}

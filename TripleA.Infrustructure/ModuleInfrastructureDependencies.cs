

using Microsoft.Extensions.DependencyInjection;
using TripleA.Infrustructure.unitOfWork;

namespace TripleA.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}

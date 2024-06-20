

using Microsoft.Extensions.DependencyInjection;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.InfrastructureBases;
using TripleA.Infrustructure.Repositories;
using TripleA.Infrustructure.unitOfWork;

namespace TripleA.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICommentRepository, CommentRepository>();

            return services;
        }

    }
}

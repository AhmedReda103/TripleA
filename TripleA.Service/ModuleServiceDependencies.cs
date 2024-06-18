using Microsoft.Extensions.DependencyInjection;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUserService, ApplicationUserService>();

            services.AddTransient<IQuestionService, QuestionService>();
            
            services.AddTransient<IAnswerService, AnswerService>(); 

            
            return services;
        }
    }
}

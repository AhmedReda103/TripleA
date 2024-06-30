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

            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<IFileService, FileService>();

            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<IUserConService, UserConService>();

            //services.AddTransient<ICashingService, CashingService>();


            return services;
        }
    }
}

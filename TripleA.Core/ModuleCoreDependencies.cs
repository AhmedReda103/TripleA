using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TripleA.Core.Bases;
using TripleA.Core.Behaviors;
using TripleA.Core.Features.Question.Commands.Handlers;
using TripleA.Core.Features.Question.Commands.Models;

namespace TripleA.Core
{
    public static class ModuleCoreDependencies
    {

        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            //Configuration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Configuration Of FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }

    }
}

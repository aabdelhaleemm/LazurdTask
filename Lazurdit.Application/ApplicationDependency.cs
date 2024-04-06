using FluentValidation;
using Lazurdit.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Lazurdit.Application;

public static class ApplicationDependency
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection service)
    {
        
        service.AddValidatorsFromAssemblyContaining<ContactValidator>();
      

        return service;
    }
}
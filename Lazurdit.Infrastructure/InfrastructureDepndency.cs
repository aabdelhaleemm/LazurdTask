using Lazurdit.Application.Common.Interfaces;
using Lazurdit.Domain.Entities;
using Lazurdit.Infrastructure.Repositories;
using Lazurdit.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lazurdit.Infrastructure;

public static class InfrastructureDependency
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection service)
    {
        service.AddSingleton<IDataBaseService<Contact>, DataBaseService<Contact>>();
        service.AddScoped<IContactRepository, ContactRepository>();
        service.AddScoped<SeedingService>();
      

        return service;
    }
}
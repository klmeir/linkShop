﻿using Catalog.Domain.Ports;
using Catalog.Domain.Services;
using Catalog.Infrastructure.Adapters;
using Catalog.Infrastructure.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Extensions
{
    public static class AutoLoadServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // generic repository
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

            // unit of work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // all services with domain service attribute, we can also do this "by convention",
            // naming services with suffix "Service" if decide to remove the domain service decorator
            var _services = AppDomain.CurrentDomain.GetAssemblies()
                  .Where(assembly =>
                  {
                      return (assembly.FullName is null) || assembly.FullName.Contains("Domain", StringComparison.InvariantCulture);
                  })
                  .SelectMany(s => s.GetTypes())
                  .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            // Ditto, but repositories
            var _repositories = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly =>
                {
                    return (assembly.FullName is null) || assembly.FullName.Contains("Infrastructure", StringComparison.InvariantCulture);
                })
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(RepositoryAttribute)));

            // svc
            foreach (var service in _services)
            {
                services.AddTransient(service);
            }

            // repos
            foreach (var repo in _repositories)
            {
                Type iface = repo.GetInterfaces().Single();
                services.AddTransient(iface, repo);
            }

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {                        
            return services;
        }
    }
}

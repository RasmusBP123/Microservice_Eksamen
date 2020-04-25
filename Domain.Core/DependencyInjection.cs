using Domain.Core.EventStore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<IRepository<AggregateRoot>, Repository<AggregateRoot>>();
            services.AddScoped<IEventStore, EventStore.EventStore>();
            services.AddScoped<IEvent, Event>();
            return services;
        }
    }
}

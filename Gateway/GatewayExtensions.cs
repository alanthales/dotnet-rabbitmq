using Gateway.EF;
using Gateway.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway
{
    public static class GatewayExtensions
    {
        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            services.AddTransient<EFGateway>();
            return services;
        }

        public static IServiceCollection AddBrokers(this IServiceCollection services)
        {
            services.AddSingleton<Connection>();
            services.AddTransient<Publisher>();
            return services;
        }
    }
}
using Core.Abstractions;
using Core.Entities;
using UseCase.Commands;
using UseCase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace UseCase
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IWriteRepository<Customer>, CustomerRepository>();
            services.AddScoped<IReadRepository<Customer>, CustomerRepository>();
            services.AddScoped<IWriteRepository<Order>, OrderRepository>();
            services.AddScoped<IReadRepository<Order>, OrderRepository>();

            services.AddScoped<CreateCustomer>();
            services.AddScoped<CreateOrder>();
            services.AddScoped<GetAllCustomers>();
            services.AddScoped<GetCustomerById>();
            services.AddScoped<GetOrdersByCustomer>();

            return services;
        }
    }
}
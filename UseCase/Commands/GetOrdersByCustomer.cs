using Core.Abstractions;
using Core.Entities;
using System;
using System.Threading.Tasks;

namespace UseCase.Commands
{
    public class GetOrdersByCustomer : ICommandHandler<Guid, Order[]>
    {
        private readonly IReadRepository<Order> _repository;

        public GetOrdersByCustomer(IReadRepository<Order> repository)
        {
            _repository = repository;
        }

        public async ValueTask<(Exception Error, Order[] Data)> Execute(Guid customerId)
        {
            try
            {
                var orders = await _repository.Where(o => o.CustomerId == customerId);
                return (null, orders);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
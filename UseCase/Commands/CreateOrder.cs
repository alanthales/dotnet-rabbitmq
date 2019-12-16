using Core.Abstractions;
using Core.Entities;
using System;
using System.Threading.Tasks;

namespace UseCase.Commands
{
    public class CreateOrder : ICommandHandler<Order, Order>
    {
        private readonly IWriteRepository<Order> _repository;

        public CreateOrder(IWriteRepository<Order> repository)
        {
            _repository = repository;
        }

        public async ValueTask<(Exception Error, Order Data)> Execute(Order order)
        {
            try
            {
                _repository.Insert(order);
                await _repository.Save();
                return (null, order);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
        
    }
}
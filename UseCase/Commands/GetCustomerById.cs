using Core.Abstractions;
using Core.Entities;
using System;
using System.Threading.Tasks;

namespace UseCase.Commands
{
    public class GetCustomerById : ICommandHandler<Guid, Customer>
    {
        private readonly IReadRepository<Customer> _repository;

        public GetCustomerById(IReadRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async ValueTask<(Exception Error, Customer Data)> Execute(Guid customerId)
        {
            try
            {
                var result = await _repository.GetById(customerId);
                return (null, result);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
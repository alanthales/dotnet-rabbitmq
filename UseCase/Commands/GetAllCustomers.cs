using Core.Abstractions;
using Core.Entities;
using System;
using System.Threading.Tasks;

namespace UseCase.Commands
{
    public class GetAllCustomers : ICommandHandler<Customer[]>
    {
        private readonly IReadRepository<Customer> _repository;

        public GetAllCustomers(IReadRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async ValueTask<(Exception Error, Customer[] Data)> Execute()
        {
            try
            {
                var result = await _repository.Get();
                return (null, result);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
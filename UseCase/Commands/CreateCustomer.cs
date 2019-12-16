using Core.Abstractions;
using Core.Entities;
using System;
using System.Threading.Tasks;

namespace UseCase.Commands
{
    public class CreateCustomer : ICommandHandler<Customer, Customer>
    {
        private readonly IWriteRepository<Customer> _repository;

        public CreateCustomer(IWriteRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async ValueTask<(Exception Error, Customer Data)> Execute(Customer customer)
        {
            try
            {
                _repository.Insert(customer);
                await _repository.Save();
                return (null, customer);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
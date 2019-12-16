using Core.Entities;
using Gateway.EF;

namespace UseCase.Repositories
{
    public class CustomerRepository : EFRepository<Customer>
    {
        public CustomerRepository(EFGateway gateway) : base(gateway)
        {
        }
    }
}
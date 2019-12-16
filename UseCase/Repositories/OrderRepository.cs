using Core.Entities;
using Gateway.EF;

namespace UseCase.Repositories
{
    public class OrderRepository : EFRepository<Order>
    {
        public OrderRepository(EFGateway gateway) : base(gateway)
        {
        }
    }
}
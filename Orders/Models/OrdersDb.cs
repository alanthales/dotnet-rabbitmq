using Microsoft.EntityFrameworkCore;

namespace Orders.Models
{
    public class OrdersDb : DbContext
    {
        public OrdersDb(DbContextOptions<OrdersDb> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
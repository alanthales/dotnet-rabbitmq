using Microsoft.EntityFrameworkCore;

namespace Bartender.Models
{
    public class BartenderDb : DbContext
    {
        public BartenderDb(DbContextOptions<BartenderDb> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
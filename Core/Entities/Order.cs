using System;

namespace Core.Entities
{
    public class Order : EntityBase
    {
        public long Number { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public Order() => Number = DateTime.UtcNow.Ticks;
    }
}
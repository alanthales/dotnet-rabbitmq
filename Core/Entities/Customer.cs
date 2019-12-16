namespace Core.Entities
{
    public class Customer : EntityBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }        
        public Address Address { get; set; }
        public Customer() => Address = new Address();
    }
}
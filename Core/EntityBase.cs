using System;

namespace Core
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; protected set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.UtcNow;
        }

        public void Map(EntityBase entity)
        {
            var props = this.GetType().GetProperties();
            foreach (var p in props)
            {
                var newValue = p.GetValue(entity);
                p.SetValue(this, newValue);
            }
        }
    }
}
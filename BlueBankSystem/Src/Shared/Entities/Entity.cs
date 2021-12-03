using System;


namespace BlueBank.System.Domain.Shared.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public bool IsActive { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
        }
    }
}

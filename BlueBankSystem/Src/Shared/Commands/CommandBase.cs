using BlueBank.System.Domain.Shared.Entities;
using BlueBank.System.Domain.Shared.Interfaces;


namespace BlueBank.System.Domain.Shared.Commands
{
    public abstract class CommandBase<TEntity> where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repository;

        protected CommandBase(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }                    
    }
}

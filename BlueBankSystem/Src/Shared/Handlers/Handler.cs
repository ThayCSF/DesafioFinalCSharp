using BlueBank.System.Domain.Shared.Entities;
using BlueBank.System.Domain.Shared.Interfaces;


namespace BlueBank.System.Domain.Shared.Handlers
{
    public abstract class Handler<TEntity, TRequest, TResponse> where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repository;
        public abstract TResponse Handle(TRequest request);
    }
}


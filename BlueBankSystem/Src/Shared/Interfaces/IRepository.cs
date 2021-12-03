using BlueBank.System.Domain.Shared.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace BlueBank.System.Domain.Shared.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        void Update(TEntity customer);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        void Remove(Guid id);
    }
}

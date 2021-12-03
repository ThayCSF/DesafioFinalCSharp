using BlueBank.System.Domain.Shared.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Data.Contexts;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace BlueBank.System.Data.Repositories
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity
    {
        private SystemContext _context;
        public Repository(SystemContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }      

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }        
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _context.Set<TEntity>().AsQueryable()
                : _context.Set<TEntity>().Where(predicate).AsQueryable();
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

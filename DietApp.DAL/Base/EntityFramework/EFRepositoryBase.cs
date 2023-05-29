using DietApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.DAL.Base.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        TContext _db;
        public EFRepositoryBase(TContext db)
        {
            _db = db;
        }
        public TEntity Add(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            return _db.SaveChanges() > 0 ? entity : null;
        }

        public void Delete(TEntity entity)
        {
            _db.Entry(entity).State &= EntityState.Deleted;
            _db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return _db.Set<TEntity>()
                .Where(filter)
                .MyIncludes(includes).FirstOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {            
            return filter == null ? _db.Set<TEntity>().MyIncludes(includes).ToList() : _db.Set<TEntity>().Where(filter).MyIncludes(includes).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _db.Entry(entity).State |= EntityState.Modified;
            return _db.SaveChanges() > 0 ? entity : null;

        }
    }
}

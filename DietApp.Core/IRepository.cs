using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Core
{
    public interface IRepository <TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);//Buradaki params ifadesiyle aslında birden fazla tablodan veriyi döndürmek istediğimiz için includsla beraber bunu sağlayabiliyoruz.
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

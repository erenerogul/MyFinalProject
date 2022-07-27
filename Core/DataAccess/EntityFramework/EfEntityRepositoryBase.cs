using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Bana bi TEntity ver bide Context türü ver demek
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
    where TEntity : class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDissposable pattern of implementation of c#
            //Using metodu çalışıp bittikten sonra garbage collectora gidip benim işim bitti beni at der
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                //EntityStatei kendin yaz ampülle sonra 
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                //Veritabanı tablosunu listeye setliyoruz burdaki set Context classında ayarladığımız list 
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                //EntityStatei kendin yaz ampülle sonra 
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

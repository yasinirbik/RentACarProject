using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //EF için evrensel bir katmandır.
    //EfCarDal^da ki katman burada evrensel bir koda dönüşerek Car yeribe TEntity , RentACar DB'si yerine de TContext yazılmış ve dilediğimiz projeye entegre edebilceğimziz(Değişkenleri değiştirerek) evrensel bir Base olarak işimizi görebilecektir
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()//IEntity'i yamasın diye newledik
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByBrandId(Func<object, object> c)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

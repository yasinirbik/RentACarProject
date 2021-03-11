using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //CORE KATMANI DİĞER KATMANLARI REFERANS ALMAZ, GENEL BİR KATMANDIR.! ! !
    public interface IEntityRepository<T> where T: class,IEntity,new ()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAllByBrandId(Func<object, object> c);
    }
}

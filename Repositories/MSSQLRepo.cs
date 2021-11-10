using Ecommerce.DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Repositories
{
    public class MSSQLRepo<T> where T:class
    {
        MSSQLContext db;
        public MSSQLRepo(MSSQLContext _db)
        {
            db = _db;
        }
        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression);
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public void Add(T model)
        {
            db.Set<T>().Add(model);
            db.SaveChanges();
        }
        public void Update(T model)
        {
            db.Set<T>().Update(model);
            db.SaveChanges();
        }
        public void Delete(T model)
        {
            db.Set<T>().Remove(model);
            db.SaveChanges();
        }
    }  

}

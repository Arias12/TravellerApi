using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected TravellerDbContext TravellerContext { get; set; }


        public Repository(TravellerDbContext travellerContext)
        {
            TravellerContext = travellerContext;
        }

        public IEnumerable<T> GetAll()
        {
            return TravellerContext.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return TravellerContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            TravellerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            TravellerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            TravellerContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            TravellerContext.SaveChanges();
        }
    }
}

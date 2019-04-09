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
        protected TravellerDbContext _travellerDbContext { get; set; }


        public Repository(TravellerDbContext travellerContext)
        {
            _travellerDbContext = travellerContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _travellerDbContext.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _travellerDbContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            _travellerDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _travellerDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _travellerDbContext.Set<T>().Remove(entity);
        }

        public bool Save()
        {
            return (_travellerDbContext.SaveChanges() >= 0);
        }
    }
}

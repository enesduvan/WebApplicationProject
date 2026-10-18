using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplicationProject.Models.Context;


namespace WebApplicationProject.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Models.Context.Context _context;
        internal DbSet<T> dbSet;  //BURAYA ERİŞİMİ SAĞLAR   
        public Repository(Models.Context.Context context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        // bu kullanım sayesinde dbset = _context.ControllerName

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {   //git verilen filtreye göre ilk kaydı getirir.
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}

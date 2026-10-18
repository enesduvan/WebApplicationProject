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

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {   //git verilen filtreye göre ilk kaydı getirir.
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}

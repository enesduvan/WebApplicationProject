using System.Linq.Expressions;

namespace WebApplicationProject.Models.Repository
{
    public interface IRepository<T> where T : class
    {
        //T parametre karşılığı entitiler 
        //<T> generictir ve asenkron olarak çalışır.
        IEnumerable<T> GetAll();

        //id isim vb şeyleri al gel 
        T Get(Expression<Func<T, bool>> filter);

        //vt CRUD
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //belirlenmiş bir aralığı sil 3 ay vs.
        void DeleteRange(IEnumerable<T> entities);
    }
}

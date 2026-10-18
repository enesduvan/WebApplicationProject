using WebApplicationProject.Models.Entities;

namespace WebApplicationProject.Models.Repository
{
    public interface IBookRepository <T> : IRepository<T> where T : class
    {
        void Guncelle(Book book);
        void Save();
    }
}

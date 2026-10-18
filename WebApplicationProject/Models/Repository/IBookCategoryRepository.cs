using WebApplicationProject.Models.Entities;

namespace WebApplicationProject.Models.Repository
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        //Ana interface IRepository<T> interface'inden türetilmiş bir interface'dir ve BookCategory entity'si için özel işlemleri tanımlar.
        void Guncelle(BookCategory bookCategory); // BookCategory entity'sini güncellemek için bir metot tanımı.
        void Kaydet(); // BookCategory entity'sini kaydetmek için bir metot tanımı. 
    }
}

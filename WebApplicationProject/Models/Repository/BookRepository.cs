using WebApplicationProject.Models.Entities;

namespace WebApplicationProject.Models.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository<Book>
    {
        private Context.Context _context;
        public BookRepository(Context.Context context) : base(context)
        {
            _context = context;
        }
        public void Guncelle(Book book)
        {
            _context.Update(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using WebApplicationProject.Models.Entities;

namespace WebApplicationProject.Models.Repository
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository 
    {
        private Context.Context _context;
        public BookCategoryRepository(Context.Context context) : base(context)
        {
            _context = context;
        }

        //iki farklı sınıfıda aldık içeriye 
        public void Guncelle(BookCategory bookCategory)
        {
           
        }

        public void Kaydet()
        {
            
        }
    }
}

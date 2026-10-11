using Microsoft.EntityFrameworkCore;

namespace WebApplicationProject.Models.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //veritabanı entitiy bağlantısı
        }
        public DbSet<Entities.BookCategory> BookCategories { get; set; } // BookCategory tablosu

    }
}

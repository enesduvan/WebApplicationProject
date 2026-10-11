using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models.Context;
using WebApplicationProject.Models.Entities;

namespace WebApplicationProject.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly Context _context; // _parametre dji injection otomatik
        public BookCategoryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BookCategory> objBookCategories = _context.BookCategories.ToList();
            Console.WriteLine(objBookCategories);
            return View();
        }
    }
}

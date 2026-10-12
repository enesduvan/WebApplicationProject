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
            
            return View(objBookCategories);
        }
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryAdd(BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.BookCategories.Add(bookCategory);
                _context.SaveChanges();
                TempData["basarili"] = "Yeni Kitap Türü başarıyla oluşturuldu!";
                return RedirectToAction("Index");
            }
            return View(bookCategory);
        }

        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.BookCategories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.BookCategories.Update(bookCategory);
                _context.SaveChanges();
                TempData["basarili"] = "Kitap Türü başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            return View(bookCategory);
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.BookCategories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public IActionResult SilPOST(int? id)
        {
            var categoryFromDb = _context.BookCategories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _context.BookCategories.Remove(categoryFromDb);
            _context.SaveChanges();
            TempData["basarili"] = "Kitap Türü başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models.Context;
using WebApplicationProject.Models.Entities;
using WebApplicationProject.Models.Repository;

namespace WebApplicationProject.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookCategoryController(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }
        public IActionResult Index()
        {
            List<BookCategory> objBookCategories = _bookCategoryRepository.GetAll().ToList();
            
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
                _bookCategoryRepository.Add(bookCategory);
                _bookCategoryRepository.Save();
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
            var categoryFromDb = _bookCategoryRepository.Get(c => c.CategoryId == id);
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
                _bookCategoryRepository.Guncelle(bookCategory);
                _bookCategoryRepository.Save();
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
            var categoryFromDb = _bookCategoryRepository.Get(c => c.CategoryId == id);
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
            var categoryFromDb = _bookCategoryRepository.Get(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _bookCategoryRepository.Delete(categoryFromDb);
            _bookCategoryRepository.Save();
            TempData["basarili"] = "Kitap Türü başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationProject.Models.Entities;
using WebApplicationProject.Models.Repository;

namespace WebApplicationProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly IBookCategoryRepository _categoryRepository;

        public BookController(IBookRepository<Book> bookRepository, IBookCategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Book> objBooks = _bookRepository.GetAll(includeProperties: "BookCategory").ToList();

            return View(objBooks);
        }
        public IActionResult Ekle()
        {
            return View("EkleGuncelle");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Add(book);
                _bookRepository.Save();
                TempData["basarili"] = "Yeni Kitap başarıyla oluşturuldu!";
                return RedirectToAction("Index");
            }
            return View("EkleGuncelle", book);
        }

        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _bookRepository.Get(c => c.Id == id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View("EkleGuncelle", bookFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Guncelle(book);
                _bookRepository.Save();
                TempData["basarili"] = "Kitap başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            return View("EkleGuncelle", book);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });
            ViewBag.CategoryList = categoryList;

            if (id == null || id == 0)
            {
                return View("EkleGuncelle");
            }
            var bookFromDb = _bookRepository.Get(c => c.Id == id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View("EkleGuncelle", bookFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EkleGuncelle(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _bookRepository.Add(book);
                    TempData["basarili"] = "Yeni Kitap başarıyla oluşturuldu!";
                }
                else
                {
                    _bookRepository.Guncelle(book);
                    TempData["basarili"] = "Kitap başarıyla güncellendi!";
                }
                _bookRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });
            return View("EkleGuncelle", book);
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _bookRepository.Get(c => c.Id == id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public IActionResult SilPOST(int? id)
        {
            var bookFromDb = _bookRepository.Get(c => c.Id == id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(bookFromDb);
            _bookRepository.Save();
            TempData["basarili"] = "Kitap başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }
}

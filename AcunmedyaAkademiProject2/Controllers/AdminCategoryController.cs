using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System.Collections.Generic;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize] // Tüm işlemler için yetkilendirme
    public class AdminCategoryController : Controller
    {
        private readonly SweetContext _context;

        public AdminCategoryController()
        {
            _context = new SweetContext();
        }

        // Kategori Listesi
        public ActionResult CategoryList()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Yeni Kategori Ekleme (GET)
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        // Yeni Kategori Ekleme (POST)
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        // Kategori Silme
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("CategoryList");
        }

        // Kategori Güncelleme (GET)
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // Kategori Güncelleme (POST)
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.Find(category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            return HttpNotFound();
        }
    }
}

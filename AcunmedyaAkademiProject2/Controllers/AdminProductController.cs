using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Entities;
using AcunmedyaAkademiProject2.Context;
using System.Collections.Generic;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminProductController : Controller
    {
        private readonly SweetContext context = new SweetContext();

        // Ürün Listesi
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        // Yeni Ürün Ekleme (GET)
        
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> categories = context.Categories
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            ViewBag.v = categories;  // Kategorileri ViewBag ile gönder
            return View();
        }

        // Yeni Ürün Ekleme (POST)
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        // Ürün Silme
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            if (value != null) // Null kontrolü eklendi
            {
                context.Products.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }

        // Ürün Güncelleme (GET)
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = context.Products.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> categories = context.Categories
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            ViewBag.v = categories; // Kategori listesi gönderildi
            return View(value);
        }

        // Ürün Güncelleme (POST)
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            if (value != null)
            {
                value.ProductName = product.ProductName;
                value.Description = product.Description;
                value.Price = product.Price;
                value.ImageUrl = product.ImageUrl;
                value.CategoryId = product.CategoryId; // Kategori güncellendi

                context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return HttpNotFound();
        }
    }
}

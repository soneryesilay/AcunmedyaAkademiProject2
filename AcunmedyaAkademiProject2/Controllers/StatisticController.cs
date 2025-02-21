using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Models; // ViewModel'i eklemeyi unutma!

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        // GET: Statistic
        SweetContext context = new SweetContext();
        public ActionResult StatisticList()
        {
            // Veritabanından verileri çek ve StatisticsViewModel'e ata.
            StatisticsViewModel model = new StatisticsViewModel();

            // Mevcut tablolarından verileri çek
            model.ProductCount = context.Products.Count();
            model.CategoryCount = context.Categories.Count();

            // ---  VAR OLMAYAN TABLOLAR İÇİN RASTGELE DEĞERLER ---
            // Bu değerleri istediğin gibi değiştirebilirsin.
            Random rnd = new Random();
            model.HappyCustomerCount = rnd.Next(50, 200); // 50 ile 200 arasında rastgele bir sayı
            model.OrderCount = rnd.Next(100, 500);        // 100 ile 500 arasında
            model.SupplierCount = rnd.Next(5, 20);       // 5 ile 20 arasında
            model.TotalStockQuantity = rnd.Next(1000, 5000); // 1000 ile 5000 arasında
            model.ActiveOrderCount = rnd.Next(10, 100);    // 10 ile 100 arasında

            // LINQ ile Min/Max fiyatları bulma (Product tablonuzdaki doğru alan adını kullanın - "Price" yerine)
            model.MinProductPrice = context.Products.Any() ? context.Products.Min(p => p.Price) : 0;  
            model.MaxProductPrice = context.Products.Any() ? context.Products.Max(p => p.Price) : 0;  
            model.AverageProductPrice = context.Products.Any() ? context.Products.Average(p => p.Price) : 0; 

            // En pahalı ve en ucuz ürünü bul (Product tablonuzdaki doğru alan adını kullanın - "ProductName" yerine)
            model.MostExpensiveProductName = context.Products.Any() ? context.Products.OrderByDescending(p => p.Price).FirstOrDefault().ProductName : "No Product"; 
            model.CheapestProductName = context.Products.Any() ? context.Products.OrderBy(p => p.Price).FirstOrDefault().ProductName : "No Product"; 

            return View(model); // Modeli View'a gönder.
        }
    }
}
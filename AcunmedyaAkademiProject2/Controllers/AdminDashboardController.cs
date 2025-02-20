using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        SweetContext context = new SweetContext();

        // GET: AdminDashboard
        public ActionResult Index()
        {
            // Get product statistics by category - with safer navigation
            // Assuming your model might have different property names
            var productsByCategory = context.Products
                .GroupBy(p => p.Category != null ? p.Category.CategoryName : "Kategorisiz")
                .Select(g => new
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count()
                })
                .ToList();

            // Convert to format needed for Google Charts
            var chartData = new List<object[]>
            {
                new object[] { "Kategori", "Ürün Sayısı" }
            };

            foreach (var item in productsByCategory)
            {
                chartData.Add(new object[] { item.CategoryName, item.ProductCount });
            }

            // Pass chart data to view
            ViewBag.ChartData = chartData;

            // Get product price statistics with null checking
            var products = context.Products.ToList();
            ViewBag.TotalProducts = products.Count();

            // Only calculate statistics if there are products
            if (products.Any())
            {
                // Assuming your price property might be named differently (Price, UnitPrice, etc.)
                // Change 'Price' to match your actual property name
                ViewBag.AveragePrice = products.Average(p => p.Price);
                ViewBag.MaxPrice = products.Max(p => p.Price);
                ViewBag.MinPrice = products.Min(p => p.Price);
            }
            else
            {
                ViewBag.AveragePrice = 0;
                ViewBag.MaxPrice = 0;
                ViewBag.MinPrice = 0;
            }

            return View();
        }
    }
}
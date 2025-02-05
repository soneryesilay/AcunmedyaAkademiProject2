using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Entities;
using AcunmedyaAkademiProject2.Context;


namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct

        SweetContext context = new SweetContext();

        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            context.Products.Add(product);
           context.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}
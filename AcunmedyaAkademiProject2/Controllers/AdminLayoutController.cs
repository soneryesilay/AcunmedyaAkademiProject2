using AcunmedyaAkademiProject2.Context;
using System.Linq;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminLayoutController : Controller
    {
        private readonly SweetContext context = new SweetContext();

        // Ürün Listesi
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialUser()
        {
            // Oturumdaki kullanıcı bilgilerini al
            var user = context.Admins.FirstOrDefault(x => x.Username == User.Identity.Name);

            // Kullanıcı bilgilerini viewa gönder
            return PartialView(user);
        }

        public PartialViewResult PartialMessage()
        {
            return PartialView();
        }

        public PartialViewResult PartialNotification()
        {
            return PartialView();
        }
    }
}
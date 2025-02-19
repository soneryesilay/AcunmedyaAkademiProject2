using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
    }
}
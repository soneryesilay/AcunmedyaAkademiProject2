using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminProfileController : Controller
    {
        private readonly SweetContext _context;

        public AdminProfileController()
        {
            _context = new SweetContext();
        }

        // Admin profilini görüntüle (MyProfile)
        public ActionResult MyProfile()
        {
            var admin = _context.Admins.FirstOrDefault();
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

   

    }
}

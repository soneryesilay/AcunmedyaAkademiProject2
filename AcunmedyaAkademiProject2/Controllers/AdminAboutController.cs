using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminAboutController : Controller
    {
        private readonly SweetContext _context;

        public AdminAboutController()
        {
            _context = new SweetContext();
        }

        // Hakkımda Listesi
        public ActionResult AboutList()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }


        // Hakkımda Güncelleme (GET)
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // Hakkımda Güncelleme (POST)
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var existingAbout = _context.Abouts.Find(about.AboutId);
            if (existingAbout != null)
            {
                existingAbout.Title = about.Title;
                existingAbout.Decsription = about.Decsription;
                existingAbout.ImageUrl = about.ImageUrl;
               
                _context.SaveChanges();
                return RedirectToAction("AboutList");
            }
            return HttpNotFound();
        }
    }
}
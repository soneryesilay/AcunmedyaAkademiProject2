using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminServiceController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult ServiceList()
        {
            var values = context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            if (value != null)
            {
                context.Services.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceId);
            if (value != null)
            {
                value.Title = service.Title;
                value.Description = service.Description;
                value.Status = service.Status;
                value.Icon = service.Icon;
                context.SaveChanges();
            }
            return RedirectToAction("ServiceList");
        }
    }
}

using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminSliderController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult SliderList()
        {
            var values = context.Sliders.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlider(Slider slider)
        {
            context.Sliders.Add(slider);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        public ActionResult DeleteSlider(int id)
        {
            var value = context.Sliders.Find(id);
            if (value != null)
            {
                context.Sliders.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var value = context.Sliders.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            var value = context.Sliders.Find(slider.SliderId);
            if (value != null)
            {
                value.Title = slider.Title;
                value.ImageUrl = slider.ImageUrl;
                value.Description = slider.Description;
                context.SaveChanges();
            }
            return RedirectToAction("SliderList");
        }
    }
}

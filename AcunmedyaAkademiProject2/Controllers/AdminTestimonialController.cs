using System.Linq;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    [Authorize]
    public class AdminTestimonialController : Controller
    {
        SweetContext context = new SweetContext();

        // REFERANSLARI LİSTELE
        public ActionResult TestimonialList()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        // YENİ REFERANS EKLE (GET)
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        // YENİ REFERANS EKLE (POST)
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                context.Testimonials.Add(testimonial);
                context.SaveChanges();
                return RedirectToAction("TestimonialList");
            }
            return View(testimonial);
        }

        // REFERANS SİL
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            if (value != null)
            {
                context.Testimonials.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("TestimonialList");
        }

        // REFERANS GÜNCELLEME (GET)
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id); 
            if (value != null)
            {
                return View(value); 
            }
            return RedirectToAction("TestimonialList"); 
        }

        // REFERANS GÜNCELLEME (POST)
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }

            var value = context.Testimonials.Find(testimonial.TestimonialId);
            if (value != null)
            {
                value.NameSurname = testimonial.NameSurname;
                value.CommentDetail = testimonial.CommentDetail;
                value.ImageUrl = testimonial.ImageUrl;

                context.SaveChanges();
                return RedirectToAction("TestimonialList"); 
            }
            return View(testimonial);  
        }
    }
}
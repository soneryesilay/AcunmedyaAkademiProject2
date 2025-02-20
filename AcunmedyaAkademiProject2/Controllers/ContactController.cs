using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        SweetContext context = new SweetContext();

        [Authorize] 
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult CreateContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Add(model);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
                return RedirectToAction("Index", "Default"); 
            }

           
            TempData["ErrorMessage"] = "Mesaj gönderilirken bir hata oluştu. Lütfen alanları kontrol edin.";
            return View(model);
        }

        [Authorize]
        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            if (value != null) 
            {
                context.Contacts.Remove(value);
                context.SaveChanges();
            } 

            return RedirectToAction("ContactList");
        }
    }
}
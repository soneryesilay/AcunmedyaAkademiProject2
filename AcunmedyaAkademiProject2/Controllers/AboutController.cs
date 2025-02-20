using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();   
            return View(values);
        }
    }
}
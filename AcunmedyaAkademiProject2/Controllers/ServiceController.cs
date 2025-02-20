using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class DefaultController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialLast6Product()
        {
            var values = context.Products
                .Where(p=>p.Category.CategoryName =="Tatlılar")
                .OrderByDescending(x => x.ProductId)
                .Take(6)
                .ToList();

            return PartialView(values);      
        }

        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTesimonial()
        {
            var values = context.Testimonials.ToList();

           
            if (values == null || !values.Any())
            {
                
                return PartialView("EmptyPartial");  
            }

            return PartialView(values);
        }

        public PartialViewResult PartialContact()
        {
            var values = context.Contacts;
            return PartialView(values);
        }

        

    }
}
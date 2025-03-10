﻿using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class ReservationController : Controller
    {
        SweetContext context = new SweetContext();

        // GET: Index (Rezervasyon oluşturma sayfası)
        public ActionResult Index()
        {
            return View(); 
        }

        [Authorize]
        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }

      



        [HttpPost]
        public ActionResult CreateReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    NumberOfPerson = model.NumberOfPerson,
                    ReservationDate = model.ReservationDate,
                    Status = false // Yeni rezervasyonun durumu false 
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

                TempData["SuccessMessage"] = "Rezervasyonunuz başarıyla alındı! En kısa sürede sizinle iletişime geçeceğiz.";
                return RedirectToAction("Index"); 
            }

            TempData["ErrorMessage"] = "Lütfen formu eksiksiz ve doğru bir şekilde doldurun."; 
            return View("Index", model); 
        }


        [Authorize]
        public ActionResult AcceptReservation(int id)
        {
            var reservation = context.Reservations.Find(id);

            if (reservation != null)
            {
                // Eğer rezervasyonun durumu false (0) ise, durumunu true (1) yap
                if (!reservation.Status)
                {
                    reservation.Status = true;
                    context.SaveChanges();
                    TempData["SuccessMessage"] = "Rezervasyon kabul edildi.";
                }
                else
                {
                    TempData["InfoMessage"] = "Bu rezervasyon zaten kabul edilmiş.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
            }

            return RedirectToAction("ReservationList"); 
        }

        // Silme işlemi (Admin için)
        [Authorize]
        public ActionResult DeleteReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Rezervasyon başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
            }

            return RedirectToAction("ReservationList"); 
        }
    }
}
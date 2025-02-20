using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunmedyaAkademiProject2.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int NumberOfPerson { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool Status { get; set; }



    }
}
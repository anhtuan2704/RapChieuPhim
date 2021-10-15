using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Số ghế")]
        public int SeatNo { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        
        [ForeignKey("Seat")]
        public int SeatID { get; set; }
        public Seat Seat { get; set; }
        [ForeignKey("Show")]
        public int ShowID { get; set; }
        public Show Show { get; set; }



    }
}
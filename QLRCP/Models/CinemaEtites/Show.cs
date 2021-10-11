using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Show
    {
        [Key]
        public int ID { get; set; }
        

        [ForeignKey("Cinema")]
        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("ShowDay")]
        public int ShowDayID { get; set; }
        public ShowDay ShowDay { get; set; }

        [ForeignKey("ShowTime")]
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class ShowTime
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Giờ chiếu")]
        public DateTime Time { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
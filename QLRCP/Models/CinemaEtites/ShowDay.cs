using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class ShowDay
    {
        [Key]
        public int Id { get; set; }

        public DateTime Day  { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
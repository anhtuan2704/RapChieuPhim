using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Discriptiion { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
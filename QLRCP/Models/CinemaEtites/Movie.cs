using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Discription { get; set; }
        public String Image { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLRCP.Models.CinemaEtites
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Tên Phim")]
        public String Name { get; set; }
        [Display(Name = "Mô tả")]
        public String Discription { get; set; }
        [Display(Name = "Ảnh")]
        public String Image { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
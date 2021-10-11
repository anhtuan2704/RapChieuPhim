using QLRCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLRCP.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
    }   
}
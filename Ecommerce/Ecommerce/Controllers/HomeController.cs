using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;


namespace Ecommerce.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {
           

            return View(db.Products.ToList());
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ShopController : Controller
    {
        public EcommerceEntities db = new EcommerceEntities();
        //
        // GET: /Shop/

        public ActionResult ByProduct(int id = 0)
        {

           Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class CartController : BaseController
    {
        EcommerceEntities1 db = new EcommerceEntities1();
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }

        //GET: /Cart/MiniCart
        public ActionResult MiniCart()
        {
            //return a partial veiw for the header
            return PartialView(this.MyOrder);
        }
       
        //
        // POST: /Cart/Add
        
        public ActionResult Add(Product product)
        {
            if (product == null)
            {
               return HttpNotFound();
            }
           
            OrderLine ol = new OrderLine();

            ol.ProductID = product.ProductID;
            
            
            return PartialView(ol);
        }
        
    }
}

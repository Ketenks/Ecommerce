using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class BaseController : Controller
    {
        //property to get our order
        private Models.Order _myOrder;
        public Models.Order MyOrder {
            get {
            //see if _myOrder is null
                if (_myOrder == null) {
                    //get the order from the database
                    _myOrder = db.Orders.Find(GetOrderID());
                }
                return _myOrder;
            }
        }
       //set up a database connection
       public EcommerceEntities1 db = new Models.EcommerceEntities1();

        public int GetOrderID()
        {
            if(Session["orderID"] == null) 
            {
                //they dont have an orderID
                //create a new order
                Order order = new Order();
                //step 2: fill in required information
                order.DateCreated = DateTime.Now;
                order.Status = "Cart";
                order.Tax = 0;
                order.Total = 0;
                order.ShippingTotal = 0;
                //add to the database
                db.Orders.Add(order);
                //save changes
                db.SaveChanges();
                //set the session variable for the orderID
                Session["orderID"] = order.OrderID;
            }
            //convert the object to a string and then to an integer
            return int.Parse(Session["orderID"].ToString());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using System.IO; //add this to save/get files

namespace Ecommerce.Controllers
{
    public class ImageController : Controller
    {
        private EcommerceEntities db = new EcommerceEntities();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Product);
            return View(images.ToList());
        }

        //
        // GET: /Image/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        //
        // POST: /Image/Create

        //add the httpPostedFileBase parameter to our post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image image, HttpPostedFileBase upload)
        {
            //handle the file upload
            //step 1: Get the filename
            string fileName = upload.FileName;
            
            
            //make a null image to pass into the database
            image.ImageURL = "";
            
            if (ModelState.IsValid)
            {
                //add the image to the database to call its properties
                db.Images.Add(image);
                //save changes
                db.SaveChanges();
                //get
                //var image1 = db.Images.Find(image.ImageID);
                var product = db.Products.Find(image.ProductID);
                
                
                //depending on the category, make a directory for that category if it doesnt exist
                if (!Directory.Exists(Server.MapPath("~/Content/Images/" + product.Category.Name)))
                {
                    //make that directory if it's not there
                    Directory.CreateDirectory(Server.MapPath("~/Content/Images/" + product.Category.Name));
                }
                //pass the new directory there since it is there no matter what
                image.ImageURL = "/Content/Images/" + product.Category.Name + "/" + fileName;

            //step 2: get the file path to save the upload 
            string filePath = Path.Combine(Server.MapPath("~/Content/Images/" + product.Category.Name), fileName);
                //upload this path to our upload object
                upload.SaveAs(filePath);
                //now add these changes to the db which includes the image
                db.SaveChanges();
                //set our view
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // GET: /Image/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // GET: /Image/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
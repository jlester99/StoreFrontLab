using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing; //Added for access to the Image datatype
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA.EF;
using StoreFrontLab.UI.MVC.Utilities; //This gives us access to our ImageUtility class
using StoreFrontLab.UI.MVC.Models;
using PagedList;
using PagedList.Mvc;

namespace StoreFrontLab.UI.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // get: products
        public ActionResult Index(string searchFilter, int categoryId = 0, int stockStatusId = 0, int page = 1)
        {
            int pageSize = 6;
            var products = db.Products
                .Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier);
            //initial instance of the products collection.  This will be filtered down based on DDL selection and/or search filter
            var prodSearchCard = db.Products.OrderBy(p => p.CategoryID).ToList();
            if (!String.IsNullOrEmpty(searchFilter))
            {
                prodSearchCard = db.Products.OrderBy(p => p.CategoryID)
                .Where(p => p.ProductName.ToLower().Contains(searchFilter.ToLower()) ||
                p.Description.ToLower().Contains(searchFilter.ToLower()))
                .Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier)
                .ToList();
                ViewBag.SelectedSearch = searchFilter;
            }
            if (categoryId != 0)
            {
                prodSearchCard = prodSearchCard.Where(p => p.CategoryID == categoryId).ToList();
                ViewBag.SelectedCategory = categoryId;
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description", categoryId);
            }
            else
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description");
            }
            if (stockStatusId != 0)
            {
                prodSearchCard = prodSearchCard.Where(p => p.StockStatusID == stockStatusId).ToList();
                ViewBag.SelectedStockStatus = stockStatusId;
                ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description", stockStatusId);
            }
            else
            {
                ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description");
            }
            return View(prodSearchCard.ToPagedList(page, pageSize));
        }

        //[Authorize]

        //get all products and show on screen with search and paging
        public ActionResult TableViewProducts(string searchFilter, int categoryId = 0, int stockStatusId = 0)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier);

            //ViewBag object used to populate the Html.DropDownList in the View
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description");

            ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description");

            //initial instance of the products collection.  This will be filtered down based on DDL selection and/or search filter
            var prodSearchTable = db.Products.OrderBy(p => p.CategoryID).ToList();


            if (!String.IsNullOrEmpty(searchFilter))
            {
                prodSearchTable = db.Products.OrderBy(p => p.CategoryID)
                .Where(p => p.ProductName.ToLower().Contains(searchFilter.ToLower()) ||
                p.Description.ToLower().Contains(searchFilter.ToLower()))
                .Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier)
                .ToList();

            }

            if (categoryId != 0)
            {
                prodSearchTable = prodSearchTable.Where(p => p.CategoryID == categoryId).ToList();
            }

            if (stockStatusId != 0)
            {
                prodSearchTable = prodSearchTable.Where(p => p.StockStatusID == stockStatusId).ToList();
            }


            return View(prodSearchTable);

        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult TableViewDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //Shopping Cart Step 3
        public ActionResult AddToCart(int qty, int productID)
        {
            //Create an empty shell for a local (local to this method) shopping cart variable
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            //Check if session-cart exists; if so, that means there were already items in the shopping cart and we need to put
            //those pre-existing items in the local shoppingCart collection we created above.
            if (Session["cart"] != null)
            {
                //session cart exists - put its items in the local shoppingCart collection so that they are easier to work with
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
                //This is unboxing. Session object gets cast back to its original, more specific type. This is explicit casting.
            }
            else
            {
                //if session cart doesnt exist yet, we need to instantiate it. (AKA new it up)
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            //find the product the user is trying to add to the cart
            Product product = db.Products.Where(b => b.ProductID == productID).FirstOrDefault();

            if (product == null)
            {
                //if a bad ID was passed to this method, kick the user back to some page to try again or we could throw an error.
                return RedirectToAction("Index");
            }
            else
            {
                //if product id IS valid, add the line-item to the cart
                CartItemViewModel item = new CartItemViewModel(qty, product);

                //put item in the local shoppingCart collection. BUT if we already have that product as a cart-item, then we will
                //update the qty only
                if (shoppingCart.ContainsKey(product.ProductID))
                {
                    shoppingCart[product.ProductID].Qty += qty;
                }
                else
                {
                    shoppingCart.Add(product.ProductID, item);
                }

                //now update the Session version of the cart so we can maintain that info between Request and Response cycles
                Session["cart"] = shoppingCart; //implicit casting aka boxing
            }

            //send them to a view that shows the list of all items in the cart
            return RedirectToAction("Index", "ShoppingCart");

        }



        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name");
            ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductImage,Description,UnitPrice,TotalUnitsSold,TotalSales,StockStatusID,CategoryID,SupplierID,ShipperID,UnitsInStock,UnitsOnOrder")] Product product, HttpPostedFileBase prodImage)
        {
            if (ModelState.IsValid)
            {
                //Image Upload utility step 6
                #region File Upload
                string file = "NoImage.png";

                if (prodImage != null)
                {
                    //Process the file that was uploaded by the user
                    file = prodImage.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };
                    //This if checks to see if the file uploaded is the right type of file
                    //i.e. file extension would be included in the goodExts
                    //We will also require the file uploaded to be 4 MB or less in size
                    if (goodExts.Contains(ext.ToLower()) && prodImage.ContentLength <= 4194304)
                    {
                        //create a new file name using a GUID (Globally Unique Identifier)
                        file = Guid.NewGuid() + ext;

                        string savePath = Server.MapPath("~/Content/assets/img/"); //this is where the images will be saved
                        Image convertedImage = Image.FromStream(prodImage.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;

                        //static example
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                    }
                }
                //no matter what, update the ProductImage with the value of the file variable
                product.ProductImage = file;
                #endregion


                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description", product.CategoryID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", product.ShipperID);
            ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description", product.StockStatusID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description", product.CategoryID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", product.ShipperID);
            ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description", product.StockStatusID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductImage,Description,UnitPrice,TotalUnitsSold,TotalSales,StockStatusID,CategoryID,SupplierID,ShipperID,UnitsInStock,UnitsOnOrder")] Product product, HttpPostedFileBase prodImage)
        {
            if (ModelState.IsValid)
            {

                //Image Upload utility step 10
                #region File Upload
                if (prodImage != null)
                {
                    //get file name
                    string file = prodImage.FileName;

                    //get the file extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    //create a list of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && prodImage.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;
                        string savePath = Server.MapPath("~/Content/assets/img/");
                        Image convertedImage = Image.FromStream(prodImage.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        if (product.ProductImage != null && product.ProductImage != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/assets/img/");
                            ImageUtility.Delete(path, product.ProductImage);
                        }

                        product.ProductImage = file; //this updates the product obj before it is saved to the DB with the latest file name
                    }
                }
                #endregion
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TableViewProducts");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description", product.CategoryID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", product.ShipperID);
            ViewBag.StockStatusID = new SelectList(db.StockStatus1, "StockStatusID", "Description", product.StockStatusID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            //Delete the image for the record that is being deleted
            string path = Server.MapPath("~/Content/assets/img/");
            ImageUtility.Delete(path, product.ProductImage);

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

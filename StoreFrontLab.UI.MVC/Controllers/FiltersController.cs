using DATA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;//added for the .Include() methods
using PagedList; //We added this using statement after installing PagedList.MVC through the Nuget Package Manager
using PagedList.Mvc;

namespace StoreFrontLab.UI.MVC.Controllers
{
    public class FiltersController : Controller
    {
        //Copied from ProductsController to provide access to the DB Objects
        //This is called a Database Context
        private MyStoreEntities db = new MyStoreEntities();

        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TableViewProducts(string searchFilter, int categoryId = 0)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier);

            //ViewBag object used to populate the Html.DropDownList in the View
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description");

            //initial instance of the products collection.  This will be filtered down based on DDL selection and/or search filter
            var prodSearchCat = db.Products.ToList();


            if (!String.IsNullOrEmpty(searchFilter))
            {
                prodSearchCat = db.Products
                .Where(p => p.ProductName.ToLower().Contains(searchFilter.ToLower()) ||
                p.Description.ToLower().Contains(searchFilter.ToLower()))
                .Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier)
                .ToList();

            }

            if (categoryId != 0)
            {
                prodSearchCat = prodSearchCat.Where(p => p.CategoryID == categoryId).ToList();
            }

            return View(prodSearchCat);

        }


        //public ActionResult ProductSearch(string searchFilter, int categoryId = 0)//set productId to 0 initially -> if a selection is changed, we will
        //                                                                 //use that value instead
        //{
        //    //ViewBag object used to populate the Html.DropDownList in the View
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Description");

        //    //initial instance of the products collection.  This will be filtered down based on DDL selection and/or search filter
        //    var products = db.Products.ToList();


        //    if (!String.IsNullOrEmpty(searchFilter))
        //    {
        //        products = db.Products
        //        .Where(p => p.ProductName.ToLower().Contains(searchFilter.ToLower()) ||
        //        p.Description.ToLower().Contains(searchFilter.ToLower()))
        //        .Include(p => p.Category).Include(p => p.Shipper).Include(p => p.StockStatus).Include(p => p.Supplier)
        //        .ToList();

        //    }

        //    if (categoryId != 0)
        //    {
        //        products = products.Where(p => p.CategoryID == categoryId).ToList();
        //    }

          
        //    return View(products);

        //}


        ////The parameter below receives the default value of 1 if nothing is passed to it
        public ActionResult ProductsPaging(string searchString, int page = 1)
        {
            int pageSize = 6; //allows us to set how many records/objects are shown per "page"

            var products = db.Products.OrderBy(p => p.CategoryID).ToList(); //this is where our paged list collection will get its data from

            if (!String.IsNullOrEmpty(searchString))
            {
                products = (
                            from p in products
                            where p.ProductName.ToLower().Contains(searchString.ToLower()) ||
                                  p.Description.ToLower().Contains(searchString.ToLower())
                            select p
                    ).ToList();
            }

            ViewBag.SearchString = searchString;

            return View(products.ToPagedList(page, pageSize));
        }

        //public ActionResult LabMagazinesMVCPaging(string searchString, int page = 1)
        //{
        //    int pageSize = 5;

        //    var magazines = db.Magazines.OrderBy(m => m.MagazineTitle).ToList();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        magazines = (
        //                from m in magazines
        //                where m.Category.ToLower().Contains(searchString.ToLower())
        //                select m
        //            ).ToList();
        //    }

        //    ViewBag.SearchString = searchString;

        //    return View(magazines.ToPagedList(page, pageSize));
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA.EF; //added for access to the domain models
using System.ComponentModel.DataAnnotations; //added for validation/display metadata

namespace StoreFrontLab.UI.MVC.Models
{
    //Shopping Cart Step 1

    //Added this viewmodel to combine domain-related info (Product Product) with other information (int Qty)
    public class CartItemViewModel
    {
        //properties
        [Range(1, int.MaxValue)]
        public int Qty { get; set; }
        public Product Product { get; set; }

        //FQ CTOR
        public CartItemViewModel(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }
    }
}
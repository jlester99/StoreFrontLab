using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }


    public class ProductMetadata
    {
        [Required(ErrorMessage = "*Product Name must contain a value.")]
        [StringLength(60, ErrorMessage = "*Name must be 60 characters or less.")]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [StringLength(300, ErrorMessage = "*Name must be 300 characters or less.")]
        [Display(Name = "Description")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Price")]
        public decimal?  UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")] //this has the wrong datatype
        [Display(Name = "Total Units Sold")]
        public decimal? TotalUnitsSold { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")] 
        [Display(Name = "Total Sales")]
        public decimal? TotalSales { get; set; }
        
        //public Nullable<int> StockStatusID { get; set; }
        //public Nullable<int> CategoryID { get; set; }
        //public Nullable<int> SupplierID { get; set; }

        [Required(ErrorMessage = "*Shipper ID must contain a value.")]
        public int ShipperID { get; set; }

        [Display(Name = "Units in Stock")]
        public short? UnitsInStock { get; set; }

        [Display(Name = "Units On Order")]
        public short? UnitsOnOrder { get; set; }


    }
}

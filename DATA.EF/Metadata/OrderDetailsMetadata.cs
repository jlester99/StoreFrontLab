using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.Metadata
{
    [MetadataType(typeof(OrderDetailsMetadata))]
    public partial class OrderDetails { }
       
    public class OrderDetailsMetadata
    {
        [Required(ErrorMessage = "*Product ID must contain a value.")]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "*Unit Price must contain a value.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "*Quantity must contain a value.")]
        [Display(Name = "Quantity")]
        public short Quantity { get; set; }

        [Required(ErrorMessage = "*Discount rate must contain a value.")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        [Display(Name = "Discount Rate")]
        public float Discount { get; set; }
    }
}

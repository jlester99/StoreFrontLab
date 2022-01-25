using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(OrderMetadata))]
    public partial class Order { }

    public class OrderMetadata
    {
        [Required(ErrorMessage = "*Customer ID must contain a value.")]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Date Shipped")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        public System.DateTime? ShippedDate { get; set; }

        [Display(Name = "Tracking Number")]
        [StringLength(50,ErrorMessage = "*Tracking Number must be 50 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string TrackingNbr { get; set; }

        //public int? ShipperID { get; set; }

        [Display(Name = "Total Shipping Amount")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[-N/A-]")]
        public decimal? TotalShipping { get; set; }

        [Display(Name = "Total Order Amount")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[-N/A-]")]
        public decimal? TotalAmt { get; set; }

    }
}

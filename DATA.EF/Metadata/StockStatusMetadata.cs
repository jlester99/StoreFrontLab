using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(StockStatusMetadata))]
    public partial class StockStatus { }

    public class StockStatusMetadata
    {
        [Required(ErrorMessage = "*Status Description must contain a value.")]
        [StringLength(20, ErrorMessage = "*Status Description must be 20 characters or less.")]
        [Display(Name = "Status")]
        public string Description { get; set; }

    }
}
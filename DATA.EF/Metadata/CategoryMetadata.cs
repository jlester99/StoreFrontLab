using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    public class CategoryMetadata
    {
        [StringLength(30, ErrorMessage = "*Category Description must be 30 characters or less.")]
        [Display(Name = "Category")]
        public string Description { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

        public class DepartmentMetadata
    {
        [Required(ErrorMessage = "*Department Name must contain a value.")]
        [StringLength(50, ErrorMessage = "*Department Name must be 50 characters or less.")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

    }
}

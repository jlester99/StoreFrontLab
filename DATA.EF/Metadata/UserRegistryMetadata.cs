using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.Metadata
{
    [MetadataType(typeof(UserRegistryMetadata))]
    public partial class UserRegistry { }

    class UserRegistryMetadata
    {
        [Required(ErrorMessage = "*First Name must contain a value.")]
        [StringLength(10, ErrorMessage = "*First Name must be 10 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last Name must contain a value.")]
        [StringLength(25, ErrorMessage = "*First Name must be 25 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
    }
}

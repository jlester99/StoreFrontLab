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

        [StringLength(70, ErrorMessage = "*Address must be 70 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "*City must be 20 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "*State must be 2 characters.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(6, ErrorMessage = "*Zip Code must be 6 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }
    }
}

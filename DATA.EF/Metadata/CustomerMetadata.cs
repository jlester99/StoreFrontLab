using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer { }

    public class CustomerMetadata

    {
        [Required(ErrorMessage = "*First Name must contain a value.")]
        [StringLength(15, ErrorMessage = "*First Name must be 15 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last Name must contain a value.")]
        [StringLength(25, ErrorMessage = "*First Name must be 25 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "*Address Line 1 must be 30 characters or less.")]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [StringLength(30, ErrorMessage = "*Address Line 2 must be 30 characters or less.")]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [StringLength(15, ErrorMessage = "*City must be 15 characters or less.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "*State must be 2 characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(15, ErrorMessage = "*Zip Code must be 15 characters or less.")]
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "*Country must be 15 characters or less.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "*Phone must be 24 characters or less.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
                
    }
}

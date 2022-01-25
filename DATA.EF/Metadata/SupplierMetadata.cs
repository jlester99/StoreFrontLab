using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.MetaData
{
    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier { }


    class SupplierMetadata
    {
        [StringLength(60, ErrorMessage = "*Name must be 60 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "*Address must be 50 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "*City must be 50 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "*State must be 2 characters.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(15, ErrorMessage = "*Zip Code must be 15 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "*Country must be 15 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "*Phone Number must be 24 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "*Fax Number must be 24 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Fax Number")]
        public string Fax { get; set; }

    }
}

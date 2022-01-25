using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF //.Metadata
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }

    public class EmployeeMetadata
    {
        //public Nullable<int> DepartmentID { get; set; }
        //public Nullable<int> DirectReportID { get; set; }


        [Required(ErrorMessage = "*Last Name must contain a value.")]
        [StringLength(25, ErrorMessage = "*First Name must be 25 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*First Name must contain a value.")]
        [StringLength(10, ErrorMessage = "*First Name must be 10 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        public string Title { get; set; }


        [Display(Name = "Birth Date")]
        public System.DateTime? BirthDate { get; set; }//add datepicker

        [Display(Name = "Date Hired")]
        public System.DateTime? HireDate { get; set; }//add datepicker

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Unit Price")]
        public decimal? Salary { get; set; }

        [StringLength(60, ErrorMessage = "*Address must be 60 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "*City must be 15 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(10, ErrorMessage = "*Zip Code must be 10 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [StringLength(15, ErrorMessage = "*Country must be 15 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "*Phone Number must be 24 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [StringLength(4, ErrorMessage = "*Phone Extension must be 4 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Phone Extension")]
        public string PhoneExt { get; set; }


        [UIHint("MultilineText")]
        [StringLength(255, ErrorMessage = "*File Path must be 255 characters or less.")]
        [Display(Name = "File Path of Employee Photo")]
        public string PhotoPath { get; set; }
    }
}

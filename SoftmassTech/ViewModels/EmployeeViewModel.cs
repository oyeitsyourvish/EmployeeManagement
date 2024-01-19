using SoftmassTech.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SoftmassTech.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is Mandatory.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Mandatory.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is Mandatory.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is Mandatory.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email address is Mandatory.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is Mandatory.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is Mandatory.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Address is Mandatory.")]
        public bool IsActive { get; set; }


        //Relationship with Department

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign Key
        public Department? Department { get; set; } //Reference navigation property

    }
}

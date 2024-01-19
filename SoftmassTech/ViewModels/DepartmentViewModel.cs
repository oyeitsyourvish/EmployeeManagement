using System.ComponentModel.DataAnnotations;

namespace SoftmassTech.ViewModels
{
    public class DepartmentViewModel
    {

        public int DepartmentId { get; set; } //Primary Key

        [Required (ErrorMessage ="Please enter department name")]
        public string Name { get; set; }
    }
}

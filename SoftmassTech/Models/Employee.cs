using System.ComponentModel.DataAnnotations.Schema;

namespace SoftmassTech.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public bool isActive { get; set; }


		//Reletionship with Department
		[ForeignKey("Department")]

		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}

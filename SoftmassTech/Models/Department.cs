namespace SoftmassTech.Models
{
	public class Department
	{
		public int DepartmentId { get; set; } //Primary Key
		public string Name { get; set; }

		//Reletionship with Employees

		/* removed by sbhat later if we want we can add.
		 public ICollection<Employee> Employees { get; set; } 
		//Collection Navigation Property.(in this case we know here single department has many employee.*/


	}
}

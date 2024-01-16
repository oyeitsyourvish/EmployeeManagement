using Microsoft.EntityFrameworkCore;
using SoftmassTech.Models;

namespace SoftmassTech.Data
{
	public class AppDbContext : DbContext
	{

		//Constructor.
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

		}

		//DbSet Properties.
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
	}
}

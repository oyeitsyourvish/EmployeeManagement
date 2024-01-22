using Microsoft.EntityFrameworkCore;
using SoftmassTech.Data;
using SoftmassTech.Models;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly AppDbContext _dbContext;

        // Dependency injection.
        public EmployeeRepository(AppDbContext dbContex)
        {
            _dbContext = dbContex;

        }

        // Implementation of IEmployeeRepository Interface
        public async Task AddAsync(EmployeeViewModel employee)
        {
            var newEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Phone =employee.PhoneNumber,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId

            };

            await _dbContext.Employees.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}

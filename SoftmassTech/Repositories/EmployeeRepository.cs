using SoftmassTech.Data;
using SoftmassTech.Models;

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
        public Task AddAsync(Employee employee)
        {
            throw new NotImplementedException();
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
    }
}

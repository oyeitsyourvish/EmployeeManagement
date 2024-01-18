using SoftmassTech.Data;
using SoftmassTech.Models;

namespace SoftmassTech.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        //Dependency Injection.
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Implementation of IDepartmentRepository Interface
        public Task AddAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}

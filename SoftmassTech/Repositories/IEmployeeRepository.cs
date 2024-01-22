using SoftmassTech.Models;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

        Task<List<Department>> GetAllDepartments();

    }
}

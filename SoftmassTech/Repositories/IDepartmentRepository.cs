using SoftmassTech.Models;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Repositories
{

    //IDepartmentRepository is our abstract layer(Repository patter) it is connection between business layer and user interface.
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);
    }
}

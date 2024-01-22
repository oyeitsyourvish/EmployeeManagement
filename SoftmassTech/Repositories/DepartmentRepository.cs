﻿using Microsoft.EntityFrameworkCore;
using SoftmassTech.Data;
using SoftmassTech.Models;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        //Dependency Injection
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            var departmentViewModel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };
            return departmentViewModel;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _dbContext.Departments.ToListAsync();
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                var departmentViewModel = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                departmentViewModels.Add(departmentViewModel);
            }

            return departmentViewModels;

        }

        public async Task AddAsync(DepartmentViewModel department)
        {
            var newDepartment = new Department()
            {
                Name = department.Name
            };
            await _dbContext.Departments.AddAsync(newDepartment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DepartmentViewModel departmentUpdated)
        {
            var department = await _dbContext.Departments.FindAsync(departmentUpdated.DepartmentId);
            department.Name = departmentUpdated.Name;

            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Department department = await _dbContext.Departments.FindAsync(Id);
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        Task<Department> IDepartmentRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Department>> IDepartmentRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}

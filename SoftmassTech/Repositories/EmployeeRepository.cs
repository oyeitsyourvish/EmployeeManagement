﻿using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAsync(int id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
           List<Employee>employees=await _dbContext.Employees.ToListAsync();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                var employeeViewModel = new EmployeeViewModel()
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth= employee.DateOfBirth,
                    Gender  = employee.Gender,
                    Email = employee.Email,
                    PhoneNumber=employee.Phone,
                    Address = employee.Address,
                    IsActive=employee.isActive,
                    DepartmentId = employee.DepartmentId

                };
                employeeViewModels.Add(employeeViewModel);
            }
            return employeeViewModels;
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {


            var employee = await _dbContext.Employees.FindAsync(id);
            var employeeViewModel = new EmployeeViewModel()
            {
                EmployeeId =employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber=employee.Phone,
                Address = employee.Address,
                IsActive=employee.isActive
            };
            return employeeViewModel;
        }

        public async Task UpdateAsync(EmployeeViewModel employeeUpdated)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeUpdated.EmployeeId);
            employee.FirstName = employeeUpdated.FirstName;
            employee.LastName = employeeUpdated.LastName;
            employee.Email = employeeUpdated.Email;
            employee.DateOfBirth = employeeUpdated.DateOfBirth;
            employee.Phone = employeeUpdated.PhoneNumber;
            employee.Address = employeeUpdated.Address;
            employee.DepartmentId = employeeUpdated.DepartmentId;
            employee.isActive = employeeUpdated.IsActive;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }

      
    }
}

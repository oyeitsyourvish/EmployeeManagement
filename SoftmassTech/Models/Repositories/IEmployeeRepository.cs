﻿namespace SoftmassTech.Models.Repositories
{
	public interface IEmployeeRepository
	{
		Task<Employee> GetByIdAsync(int id);	
		Task<List<Employee>> GetAllAsync();
		Task AddAsync(Employee employee);
		Task UpdateAsync(Employee employee);
		Task DeleteAsync(int id);

	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftmassTech.Models;
using SoftmassTech.Repositories;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
        }
        public async Task <IActionResult> Index(string searchString, string sortOrder)
        {
            //Fetching data from database
            var employees = await _employeeRepository.GetAllAsync();


            // using name searching bar creation
            if(!String.IsNullOrEmpty(searchString))
            {
                employees =employees.Where(n=> n.FirstName.Contains(searchString)
                || n.LastName.Contains(searchString)|| n.Gender.Contains(searchString) || n.PhoneNumber.Contains(searchString)).ToList();
            }


            // SORTING THE DATA 
            // ViewData["CurrentSort"] = sortOrder;
            //sorting data by name
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //sorting data by DOB
            ViewData["DateOfBirthSortParm"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName).ToList();
                    break;

                case "date_asc":
                    employees = employees.OrderBy(s => s.DateOfBirth).ToList();
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.DateOfBirth).ToList();
                    break;

                default:
                    employees = employees.OrderBy(e => e.FirstName).ToList();
                    break;
            }

            return View(employees);
        }


        [HttpGet] //when we clicked on add employee this method will be called.
        public async Task <IActionResult> Add()
        {
            var departments = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
          
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Add(EmployeeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //insert data in database.
            await _employeeRepository.AddAsync(model);

            //redirect to list all page
            return RedirectToAction("Index","Employee");

        }

        //GET:when we click on edit 
        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            //Fetch department dropdown .
            var departments = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            //Fetch employee details
            var employee= await _employeeRepository.GetByIdAsync(id);

            return View(employee);
        }



        //POST: when we click on submit edit data.
        [HttpPost]
        public async Task <IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee); // Return to the form with validation errors
            }
            //Update the database with modified details
            await _employeeRepository.UpdateAsync(employee);

            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");
        }


        public async Task <IActionResult> Delete(int id)
        {
            // Delete data from database.
            await _employeeRepository.DeleteAsync(id);

            //Redirect to all employee.
            return RedirectToAction("Index", "Employee");

        }
        
    }
}

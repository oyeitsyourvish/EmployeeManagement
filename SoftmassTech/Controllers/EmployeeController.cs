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
        public async Task <IActionResult> Index()
        {
            //Fetching data from database
            var employees = await _employeeRepository.GetAllAsync();
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

        //GET: Employee/Edit
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



        //POST: Employee/Edit
        [HttpPost]
        public IActionResult Edit()
        {

            return View();
        }
        
    }
}

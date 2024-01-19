using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftmassTech.Models;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet] //when we clicked on add employee this method will be called.
        public IActionResult Add()
        {
            List<Department> departments = new List<Department>
            {
                new Department { DepartmentId = 1, Name = "HR" },
                new Department { DepartmentId = 1, Name = "Data Analyst" }
            };
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
          
            return View();
        }


        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}

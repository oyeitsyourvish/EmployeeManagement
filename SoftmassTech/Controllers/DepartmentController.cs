using Microsoft.AspNetCore.Mvc;
using SoftmassTech.Repositories;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }
        public async Task <IActionResult> Index()
        {
            //fetching data from database
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }


        [HttpGet] //when we clicked on add department this method will be called.
        public IActionResult Add()
        {
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model); // it will show the error

            }

            // Insert to the database
            await  _departmentRepository.AddAsync(model);

            //Redirect to list all department.
            return RedirectToAction("Index","Department");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Delete Department data from db.
            await _departmentRepository.DeleteAsync(id);

            //after deleting redirect
            return RedirectToAction("Index","Department");


        }
    }
}

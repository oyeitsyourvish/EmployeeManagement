using Microsoft.AspNetCore.Mvc;
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

          
            return View();
        }


        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}

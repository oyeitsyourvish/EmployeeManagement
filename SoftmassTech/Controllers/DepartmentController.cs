using Microsoft.AspNetCore.Mvc;
using SoftmassTech.ViewModels;

namespace SoftmassTech.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet] //when we clicked on add department this method will be called.
        public IActionResult Add()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Add(DepartmentViewModel model)
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModels;
namespace Project.Controllers
   
{
    public class StudentController : Controller
    {
        public ViewResult Display() 
        {
            return View();
        }
    }
}

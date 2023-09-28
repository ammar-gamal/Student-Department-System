using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Project.BLL;
using Project.Context;
using Project.Models;

namespace Project.Controllers
{
    public class StudentsController : Controller
    {
       // StudentBLL studentBLL;
        IStudent studentBLL;
        IDepartment departmentBLL;

        public StudentsController(IStudent studentBLL, IDepartment departmentBLL)
        {
            this.studentBLL = studentBLL;
            this.departmentBLL = departmentBLL;
        }

        //public  IActionResult NotFound()
        //{
        //    return View();
        //}

        private void DisplayDeptsInForm()
        {
            var list = departmentBLL.GetAll();
            ViewBag.departments = new SelectList(list, "deptId", "deptName");
        }
        public ViewResult Index()
        {
            var list = studentBLL.getAll();
          
            return View(list);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var stud = studentBLL.getByID(id);
            if (stud == null)
                return View("StudentNotFound");
            return View(stud);
        }
        public IActionResult Delete(int ?id)
        {
            if (id == null)
                return BadRequest();
            studentBLL.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            //must send the all departmetns to user to choose one of them 
            DisplayDeptsInForm();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                studentBLL.Add(stud);
                return RedirectToAction("Index");
            }
            //if you in view and you want to go to another view must use redirection 
            else
            {
                DisplayDeptsInForm();
                return View(stud);
            }
        }
        [HttpGet]
        public IActionResult Update(int ?id)
        {
            //here we will display the form  of this student
            if (id == null)
                return BadRequest();
            Student stud = studentBLL.getByID(id);
            if (stud == null)
                return View("StudentNotFound");
            DisplayDeptsInForm();
            return View(stud);

        }
        [HttpPost]
        public IActionResult Update(Student stud)
        {   //in update i must get the new data that i want to update 
            //when i be in this function i have all new data and if not changed it will be the same
            if (ModelState.IsValid)
            {
                studentBLL.Update(stud);
                return RedirectToAction("index");
            }
            else
            {
                DisplayDeptsInForm();
                return View(stud);
            }
        }
    }
}

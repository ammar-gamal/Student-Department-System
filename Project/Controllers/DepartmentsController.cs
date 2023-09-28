using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.Models;

namespace Project.Controllers
{
    public class DepartmentsController : Controller
    {
        IDepartment departmentBLL;

        public DepartmentsController(IDepartment departmentBLL)
        {
            this.departmentBLL = departmentBLL;
        }

        public IActionResult Index()
        {
            var list = departmentBLL.GetAll();
            return View(list);
        }
        public IActionResult Details(int ?Deptid)
        {
            if (Deptid == null)
                return BadRequest();
            var department = departmentBLL.getByID(Deptid);
            if (department == null)
                return NotFound();
            return View(department);
        }
        public IActionResult Delete(int ?deptID)
        {
            if (deptID == null)
                return BadRequest();
            departmentBLL.Delete(deptID);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentBLL.Add(department);
                return RedirectToAction("index");
            }
            else
            {
                return View(department);
            }
        }
        [HttpGet]
        public IActionResult Update(int? deptid)
        {
            if (deptid == null)
                return BadRequest();
            Department department = departmentBLL.getByID(deptid);
            if (department == null)
                return NotFound();

            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentBLL.Update(department);
                return RedirectToAction("index");
            }
            else
            {
                return View(department);
            }
        }
        public IActionResult StudentDetails(int? id)
        {
            if (id == null)
                return BadRequest();
            var student = departmentBLL.getStudent(id);
            if (student == null)
                return NotFound();
            return View(student);
        }
        public IActionResult DeleteStudent(int? id)
        {
            if (id == null)
                return NotFound();
            int?deptId=departmentBLL.DeleteStudent(id);
            return RedirectToAction("Details",new { deptId });
        }
    }
}

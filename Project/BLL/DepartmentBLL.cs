using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;
using System.ComponentModel;

namespace Project.BLL
{
    public class DepartmentBLL:IDepartment
    {
        ContextApp DB = new ContextApp();
        public List<Department> GetAll()
        {
            var list = DB.Departments.ToList();
            return list;
        }
        public void Add(Department department)
        {
            DB.Departments.Add(department);
            DB.SaveChanges();
        }
        public Department getByID(int ?deptID)
        {
           var department= DB.Departments.Include(e=>e.Students).SingleOrDefault(d=> deptID == d.deptId);
            return department;
        }
        public void Delete(int? deptID)
        {
            var delDept = getByID(deptID);
            if (delDept == null) return;
            DB.Departments.Remove(delDept);
            DB.SaveChanges();
        }
        public void Update(Department department)
        {
            DB.Departments.Update(department);
            DB.SaveChanges();
        }
        public Student getStudent(int? studID)
        {
            var stud = DB.Students.Find(studID);
            return stud;
        }
        public int? DeleteStudent(int? studID) //must return id of department because we need it for the view
        {
            var stud = DB.Students.Find(studID);
            int? deptNo = stud.DeptNo;
            stud.DeptNo = null;
            DB.Students.Update(stud);
            DB.SaveChanges();
            return deptNo;
        }
    }
}

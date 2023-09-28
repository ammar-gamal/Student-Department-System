using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.BLL
{
    public class StudentBLL:IStudent
    {
        private ContextApp DB = new ContextApp();

        public List<Student> getAll()
        {
            var list = DB.Students.Include(d => d.Department).ToList();
            return list;
        }
        public Student getByID(int? id)
        {
            var stud = DB.Students.Include(d => d.Department).SingleOrDefault(s => s.id == id);
            return stud;
        }
        public void Add(Student stud)
        {
            DB.Students.Add(stud);
            DB.SaveChanges();
        }
        public void Delete(int? id)
        {
            var delStud = getByID(id);
            if (delStud == null) return;
            DB.Students.Remove(delStud);
            DB.SaveChanges();
        }
        public void Update(Student stud)
        {
            DB.Students.Update(stud);
            DB.SaveChanges();
        }
    }
}

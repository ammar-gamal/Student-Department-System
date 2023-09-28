using Project.Models;

namespace Project.BLL
{
    public interface IDepartment
    {
        public List<Department> GetAll();
        public void Add(Department department);
        public Department getByID(int? deptID);
        public void Delete(int? deptID);
        public void Update(Department department);
        public Student getStudent(int? studID);
        public int? DeleteStudent(int? studID);
    }
}

using Project.Models;

namespace Project.BLL
{
    public interface IStudent
    {
        public List<Student> getAll();
        public Student getByID(int? id);
        public void Add(Student stud);
        public void Delete(int? id);
        public void Update(Student stud);




    }
}

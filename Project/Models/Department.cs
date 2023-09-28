using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None),Display(Name ="Department ID")]
        public int deptId { get; set; }
        [Display(Name = "Department Name"),Required(ErrorMessage ="*"),StringLength(50)]
        public string deptName { get; set; }
     
        public override string ToString()
        {
            return $"Department Name :{deptName}      Department ID :{deptId}";
        }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>(); 

    }
}

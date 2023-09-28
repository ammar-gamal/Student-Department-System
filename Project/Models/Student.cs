using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Project.Models
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public AgeRangeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;

                if (age >= _minAge && age <= _maxAge)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Age must be between {_minAge} and {_maxAge} years.");
                }
            }

            return new ValidationResult("Invalid date format or value.");
        }
    }
    public class Student
    {
        public int id { get; set; }
        [StringLength(20,MinimumLength =5),Required(ErrorMessage ="*")]
        public string Password { get; set; }
        [NotMapped,Compare("Password"),Display(Name="Confirm Password")]
        public string CPassword { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+[.][a-zA-Z]{2,4}", ErrorMessage = "email does not match pattern"),DataType(DataType.EmailAddress),Required(ErrorMessage ="*")]
        public string Email { get; set; }

        [Required(ErrorMessage ="*"),StringLength(7)]
        public string Gender { get; set; }
 
        [Display(Name = "Age"),NotMapped]
        public int Age { get 
            { return DateTime.Now.Year - DoB.Year;  } 
        }

        [StringLength(200,MinimumLength =5)]
        public string Address { get; set; }

        [Display(Name = "Full Name"), StringLength(30,MinimumLength =5), Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [DataType(DataType.Date),Column(TypeName = "Date"), Display(Name = "BirthDate"),Required]
        [AgeRange(20, 40)]
        public DateTime DoB { get; set; }
     
        [Display(Name ="Department"), ForeignKey("Department")]
        public int? DeptNo{ get; set; }
        public virtual Department Department{ get; set; }
        public override string ToString()
        {
            return $"Name :{Name} Age: {Age} ID :{id}";
        }

    }
}

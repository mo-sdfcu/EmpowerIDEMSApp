using System.ComponentModel.DataAnnotations;

namespace EmpowerIDEMSApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Full Name is a required field")]
        public string FullName { get; set; }
        
        [Required(ErrorMessage ="Email Address is a required field")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage ="Date of birth is a required field")]
        public DateTime BirthDate { get; set; }


        [Required (ErrorMessage ="Department name is a required field")]
        public string DepartmentName { get; set; }
    }
}

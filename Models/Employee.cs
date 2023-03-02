using System.ComponentModel.DataAnnotations;

namespace EmpowerIDEMSApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a vaild email address")]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}

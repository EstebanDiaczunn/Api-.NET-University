using System.ComponentModel.DataAnnotations;
namespace Api_esteban.Models.DataModels
{
    public class Student : BaseEntity
    {
        [RequiredAttribute]
        public string Name { get; set; } = string.Empty;
        
        [RequiredAttribute]
        public string LastName { get; set; } = string.Empty;

        [RequiredAttribute]
        public DateTime Dob { get; set; }

        [RequiredAttribute]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
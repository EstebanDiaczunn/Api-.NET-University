using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Api_esteban.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name {get; set;} = string.Empty;
        
        [Required]
        public ICollection<Course> Courses {get; set;} = new List<Course>();

    }
    public enum Levels
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
}
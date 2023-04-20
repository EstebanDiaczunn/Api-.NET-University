using System.ComponentModel.DataAnnotations;
namespace Api_esteban.Models.DataModels
{
    public class Chapter : BaseEntity
    {   
        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course(); 
        public string List = string.Empty;
    }
}
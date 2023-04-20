using System.ComponentModel.DataAnnotations;
namespace Api_esteban.Models.DataModels
{

public class Course : BaseEntity
{ 
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Required, StringLength(280)]
    public string ShortDescription { get; set; } = string.Empty;
    
    [Required]
    public string LongDescription { get; set; } = string.Empty;
    
    [Required, StringLength(30)]
    public string TargetAudiences { get; set; } = string.Empty;
    
    [Required, StringLength(140)]
    public string Goals { get; set; } = string.Empty;
    
    [Required, StringLength(140)]
    public string Requirements { get; set; } = string.Empty;

    [Required] 
    public Levels Level { get; set; } = Levels.Basic;

    [Required] 
    public ICollection<Category> Categories { get; set; } = new List<Category>();

    [Required] 
    
    public Chapter Chapter { get; set; } = new Chapter();    

    [Required] 
    public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
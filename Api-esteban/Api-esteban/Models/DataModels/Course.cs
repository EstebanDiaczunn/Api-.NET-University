using System.ComponentModel.DataAnnotations;
namespace Api_esteban.Models.DataModels
{

public class Course : BaseEntity
{ 
    [RequiredAttribute, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [RequiredAttribute, StringLength(280)]
    public string ShortDescription { get; set; } = string.Empty;
    
    [RequiredAttribute]
    public string LongDescription { get; set; } = string.Empty;
    
    [RequiredAttribute, StringLength(30)]
    public string TargetAudiences { get; set; } = string.Empty;
    
    [RequiredAttribute, StringLength(140)]
    public string Goals { get; set; } = string.Empty;
    
    [RequiredAttribute, StringLength(140)]
    public string Requirements { get; set; } = string.Empty;

    [RequiredAttribute] 
    public Levels Level { get; set; } = Levels.Basic;

    [RequiredAttribute] 
    public ICollection<Category> Categories { get; set; } = new List<Category>();

    [RequiredAttribute] 
    
    public Chapter Chapter { get; set; } = new Chapter();    

    [RequiredAttribute] 
    public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
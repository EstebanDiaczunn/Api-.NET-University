using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace Api_esteban.Models.DataModels;

public enum Level
{
    Basico,
    Intermedio,
    Avanzado
}

public class Course
{ 
    [Required, StringLength(30)]
    public string Name { get; set; } = string.Empty;
    
    [Required, StringLength(280)]
    public string ShortDescription { get; set; } = string.Empty;
    
    [Required, StringLength(360)]
    public string LongDescription { get; set; } = string.Empty;
    
    [Required, StringLength(30)]
    public string TargetAudiences { get; set; } = string.Empty;
    
    [Required, StringLength(140)]
    public string Goals { get; set; } = string.Empty;
    
    [Required, StringLength(140)]
    public string Requirements { get; set; } = string.Empty;

    [Required] public Level? Level { get; set; } = null!;

}
using System.ComponentModel.DataAnnotations;

namespace Api_esteban.Models.DataModels;

public class Group 
{
    [Key] public string GroupName { get; set; } = null!; //Ej : Users
    
    public string? Description { get; set; }
    
    public virtual ICollection<UserGroup>? UserGroups { get; set; }
}
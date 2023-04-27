using System.ComponentModel.DataAnnotations;

namespace Api_esteban.Models.DataModels;

public class UserGroup
{
    [Key] public string UserName { get; set; } = null!;
    [Key] public string GroupName { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    public virtual Group Group { get; set; } = null!;
}
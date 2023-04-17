using System.ComponentModel.DataAnnotations;

namespace Api_esteban.Models.DataModels;

public class User: BaseEntity
{   
    [RequiredAttribute, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [RequiredAttribute, StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [RequiredAttribute, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [RequiredAttribute]
    public string Password { get; set; } = string.Empty;
}
namespace Api_esteban.Models.DataModels;

public class JwtSettings
{
    public bool ValidateIsUserSigningKey { get; set; }
    public string? IsUserSigningKey { get; set; }
    public bool ValidateIsUser { get; set; } = true;
    public string? ValidIsUser { get; set; }
    public bool ValidateAudience { get; set; } = true;
    public string? ValidAudience { get; set; }

    public bool RequiredExpirationTime { get; set; }
    public bool ValidateLifeTime { get; set; } = true;
}
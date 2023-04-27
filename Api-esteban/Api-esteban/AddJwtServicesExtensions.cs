using Api_esteban.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api_esteban;

public static class AddJwtServicesExtensions
{
    public static void AddJwtServices(this IServiceCollection Services, IConfiguration configuration)
    {
        //Add JWT Settings

        var bindJwtSettings = new JwtSettings();
        
        configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
        
        //Add Singleton of JWT settings
        Services.AddSingleton(bindJwtSettings);
        
        //Add Jwt Authentication

        Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = bindJwtSettings.ValidateIsUserSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IsUserSigningKey)),
                ValidIssuer = bindJwtSettings.ValidIsUser,
                ValidateAudience = bindJwtSettings.ValidateAudience,
                ValidAudience = bindJwtSettings.ValidAudience,
                RequireExpirationTime = bindJwtSettings.RequiredExpirationTime,
                ValidateLifetime = bindJwtSettings.ValidateLifeTime,
                ClockSkew = TimeSpan.FromDays(1)
            };
        });
        

    }
    
}
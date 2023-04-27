using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api_esteban.Models.DataModels;
using Microsoft.IdentityModel.Tokens;

namespace Api_esteban.Helpers;

public static class JwtHelpers
{
    public static IEnumerable<Claim> GetClaims(this UserTokens userAcounts, Guid Id)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("Id", userAcounts.Id.ToString()),
            new Claim(ClaimTypes.Name, userAcounts.UserName),
            new Claim(ClaimTypes.Email, userAcounts.EmailId),
            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MM ddd dd yy HH:mm:ss: tt"))
        };

        if (userAcounts.UserName == "Admin")
        {
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
        }else if (userAcounts.UserName == "User 1")
        {
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim("UserOnly","User 1"));
        }
        return  claims;
    }

    public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
    {
        Id = Guid.NewGuid();
        return  GetClaims(userAccounts, Id);
    }
    
    public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
    {
        try
        {
            var userToken = new UserTokens();
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
            //Obtain SECRET KEY
            if (jwtSettings.IsUserSigningKey != null)
            {
                var key = Encoding.ASCII.GetBytes(jwtSettings.IsUserSigningKey) ;

                Guid Id;
            
                //Expires in 1 Days
                DateTime expireTime = DateTime.UtcNow.AddDays(1);
            
                //validity of our token
                userToken.Validity = expireTime.TimeOfDay;
            
                //GENERATE OUR JWT
                var JwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIsUser,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));
            
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(JwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
            }

            return userToken;

        }
        catch (Exception e)
        {
            throw new Exception("Error generando el JWT", e);
        }
    }
}
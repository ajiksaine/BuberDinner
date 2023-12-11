using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Services;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    // Generate a 256-bit (32 bytes) key
    private byte[] secretKey = KeyGenerator.GenerateRandomKey(32);
    private readonly IDatetimeProvider _datetimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDatetimeProvider datetimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _datetimeProvider = datetimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        // var signingCredentials = new SigningCredentials(
        //     new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);


        var claims = new[]
        {

            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _datetimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
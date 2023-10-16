﻿using Core.Extensions;
using Core.Utilities.Security.Encyrption;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Core.Utilities.Security.Jwt;


public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; } //appsettings.json dosyasını okumamızı sağlar
    private TokenOptions _tokenOptions; //appsettins.json dan gelen bilgileri içeriyor
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsettings içerisindeki tokenoptions'ı al yandaki class'a verileri ata
    }
    public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //token ne zaman bitecek
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //kullanacağımız algoritma
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //hangi kullanıcı için,
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };

    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
        SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now, //şuandan önce bir değer verilemez
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
            );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims;
    }
}

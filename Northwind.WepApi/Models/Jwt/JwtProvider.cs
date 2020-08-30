using Microsoft.IdentityModel.Tokens;
using Northwind.Models.Models;
using Northwind.WepApi.Autentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Northwind.WepApi.Models.Jwt
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key { get; set; }
        private string _algoritm { get; set; }
        private string _issuer { get; set; }
        private string _audience { get; set; }

        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters() { KeyContainerName = keyName };
            var provider = new RSACryptoServiceProvider(2048, parameters);

            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSsaPssSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }

        public string CreateToken(User user, DateTime expiry)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var identity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}" ),
                    new Claim(ClaimTypes.Role, $"{user.Roles} {user.LastName}" ),
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                },"Custom");

                SecurityToken token = tokenHandler.CreateJwtSecurityToken( new SecurityTokenDescriptor
                { 
                    Audience = _audience,
                    Issuer = _issuer,
                    SigningCredentials = new SigningCredentials(_key, _algoritm),
                    Expires = expiry.ToUniversalTime(),
                    Subject = identity
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TokenValidationParameters GetValidationParameters()
        {
            throw new NotImplementedException();
        }
    }
}

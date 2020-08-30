using Microsoft.IdentityModel.Tokens;
using Northwind.Models.Models;
using System;

namespace Northwind.WepApi.Autentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}

namespace Northwind.WepApi.Models.Jwt
{
    public class JasonWebToken
    {
        public string Acces_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Expires_in { get; set; }
        public string Refresh_Token { get; set; }
    }
}

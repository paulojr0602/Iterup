using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APIWeb.Security
{
   /// <summary>
   /// Classe de Segurança do Token.
   /// Autor: Paulo Roberto de Almeida Jr. Data:16/07/2020
   /// </summary>
   public class SigningConfigurations
   {
      private const string SECRET_KEY = "c1f51f42-6229-4d15-b787-c6bbbb198048";
      public SigningCredentials SigningCredentials { get; }
      private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

      public SigningConfigurations()
      {
         SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256); ;
      }
   }
}

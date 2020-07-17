namespace APIWeb.Security
{
   /// <summary>
   /// Classe de Token.
   /// Autor: Paulo Roberto de Almeida Jr. Data:16/07/2020
   /// </summary>
   public class TokenConfigurations
   {
      public string Audience { get; set; }
      public string Issuer { get; set; }
      public int Seconds { get; set; }
   }
}

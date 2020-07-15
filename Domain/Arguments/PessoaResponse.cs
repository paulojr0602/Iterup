using Domain.Entities;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Argumentos de Pessoas Response
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class PessoaResponse
   {
      public Pessoa _pessoa { get; set; }

      public static explicit operator PessoaResponse(Pessoa entidade)
      {
         if (entidade == null) { return new PessoaResponse(); }

         return new PessoaResponse()
         {
            _pessoa = entidade
         };
      }
      
   }
}

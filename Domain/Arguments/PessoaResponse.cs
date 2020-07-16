using Domain.Entities;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Argumentos de Pessoas Response
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class PessoaResponse
   {
      public int Id { get; private set; }
      public string Nome { get; private set; }
      public string CPF { get; private set; }
      public string DataNascimento { get; private set; }
      //public int IdUf { get; set; }
      public UF Uf { get; set; }

      public static explicit operator PessoaResponse(Pessoa entidade)
      {
         if (entidade == null) { return new PessoaResponse(); }

         return new PessoaResponse()
         {
            Id = entidade.Id,
            Nome = entidade.Nome,
            CPF = entidade.CPF,
            DataNascimento = entidade.DataNascimento,
            Uf = new UF(entidade.IdUf, entidade.Uf.Sigla, entidade.Uf.Estado)
         };
      }
      
   }
}

using Domain.Entities;

namespace Domain.Arguments
{
   public class UsuarioAutenticadoResponse
   {
      public int Id { get; set; }
      public string Nome { get; set; }
      public string Cpf  { get; set; }

      public static explicit operator UsuarioAutenticadoResponse(Pessoa entidade)
      {
         if (entidade == null) { return new UsuarioAutenticadoResponse(); }

         return new UsuarioAutenticadoResponse()
         {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Cpf = entidade.CPF,
         };
      }
   }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Usuario Response
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class UsuarioResponse
   {
      public UsuarioResponse()
      {
      }

      public UsuarioResponse(int id, string mensagem)
      {
         Id = id;
         this.mensagem = mensagem ?? throw new ArgumentNullException(nameof(mensagem));
      }

      public int Id { get; set; }
      public string mensagem { get; set; }
      public string PrimeiroNome { get; set; }

      //Utilizado para retornar o resultado no ServicoUsuario ao autenticar-se
      public static explicit operator UsuarioResponse(Usuario entidade)
      {
         return new UsuarioResponse()
         {
            Id = entidade.Id,
            PrimeiroNome = entidade.Nome.PrimeiroNome
         };
      }
   }
}

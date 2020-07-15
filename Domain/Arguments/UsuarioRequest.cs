using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Usuario Request
   /// Autor:Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Utilizada para realizar as requisições da API como Cadastrar, Editar e Autenticar um usuario
   /// </summary>
   public class UsuarioRequest
   {
      public UsuarioRequest(string primeiroNome, string ultimoNome, string email, string senha)
      {
         PrimeiroNome = primeiroNome ?? throw new ArgumentNullException(nameof(primeiroNome));
         UltimoNome = ultimoNome ?? throw new ArgumentNullException(nameof(ultimoNome));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         Senha = senha ?? throw new ArgumentNullException(nameof(senha));
      }

      public string PrimeiroNome { get; set; }
      public string UltimoNome { get; set; }
      public string Email { get; set; }
      public string  Senha { get; set; }
   }
}

using System;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Usuario Request
   /// Autor:Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Utilizada para realizar as requisições da API como Cadastrar, Editar e Autenticar um usuario
   /// </summary>
   public class UsuarioRequest
   {
      public UsuarioRequest(string cpf, string senha)
      {
         Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
         Senha = senha ?? throw new ArgumentNullException(nameof(senha));
         
      }

      public string Cpf { get; set; }
      public string Senha { get; set; }
   }
}

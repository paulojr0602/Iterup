using Domain.Entities.Base;
using Domain.ObjectValue;

namespace Domain.Entities
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Classe de Entidade de Usuario
   /// </summary>
   public class Usuario: EntityBase
   {
      protected Usuario()
      {
      }

      public Usuario(Email email, string senha)
      {
         Email = email;
         Senha = senha;

         //Conversão da senha para Criptografia MD5;
         //Senha = Senha.ConvertToMD5();
      }

      public Usuario(NomeDeUsuario nome, Email email, string senha)
      {
         Nome = nome;
         Email = email;
         Senha = senha;

         //Conversão da senha para Criptografia MD5;
         //Senha = Senha.ConvertToMD5();

      }

      public Usuario(int id, NomeDeUsuario nome, Email email, string senha) : this(nome, email, senha)
      {
      }

      public NomeDeUsuario Nome { get; private set; }
      public Email Email { get; private set; }
      public string Senha { get; private set; }

   }
}

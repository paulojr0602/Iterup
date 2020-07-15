using Domain.Entities;
using System;

namespace Domain.Interfaces.IRepository
{
   /// <summary>
   /// Interface de Repositorio de Usuario
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public interface IRepositoryUsuario
   {
      Usuario ConsultarUsuarioPorId(int id);
      Usuario ConsultarUsuarioPorEmailSenha(string email, string senha);
      Usuario ConsultarUsuarioPorEmail(string email);
      string Cadastrar(Usuario usuario);
      bool Existe(string email);
      string AlterarUsuario(string email);
      Exception AlterarSenha(string email, string novaSenha);
   }
}

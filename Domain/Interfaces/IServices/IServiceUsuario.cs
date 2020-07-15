using Domain.Arguments;
using Domain.Arguments.Base;
using Domain.Interfaces.IServices.Base;

namespace Domain.Interfaces.IServices
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:17/04/2020
   /// Interface de Servico de Usuario
   /// </summary>
   public interface IServiceUsuario: IServiceBase
   {
      UsuarioResponse CadastrarUsuario(UsuarioRequest request);
      UsuarioResponse AutenticarUsuario(UsuarioRequest request);
      Response ValidarEmail(string email);
   }
}

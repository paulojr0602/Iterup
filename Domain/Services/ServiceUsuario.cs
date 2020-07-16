using Domain.Arguments;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.ObjectValue;
using System;
using Response = Domain.Arguments.Base.Response;

namespace Domain.Services
{
   /// <summary>
   /// Classe de Implementação do Serviço da Usuário
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class ServiceUsuario : IServiceUsuario
   {
      //Dependencia do Serviço de Usuário
      private readonly IRepositoryUsuario repositoryUsuario;
      //Construtor do Servico que recebe a dependencia da Arquitetura
      public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
      {
         this.repositoryUsuario = repositoryUsuario;
      }

      public UsuarioResponse AutenticarUsuario(UsuarioRequest request)
      {
         throw new NotImplementedException();
      }

      public UsuarioResponse CadastrarUsuario(UsuarioRequest request)
      {
         if (request == null)
         {
            throw new Exception("Parâmetros inválidos.");
         }

         //Monta o objeto
         NomeDeUsuario nomeDeUsuario = new NomeDeUsuario(request.PrimeiroNome, request.UltimoNome);
         Email email = new Email(request.Email);
         Usuario usuario = new Usuario(nomeDeUsuario, email, request.Senha);

         //Persiste após as validações
         string mensagem = repositoryUsuario.Cadastrar(usuario);
         if (String.IsNullOrEmpty(mensagem))
         {
            return new UsuarioResponse(usuario.Id, "Usuário Cadastrado.");
         }
         return new UsuarioResponse(usuario.Id, "Este email: " + email.EnderecoEletronico + " já existe no sistema.");
      }
   

      public void Dispose()
      {
         throw new NotImplementedException();
      }

      public Response ValidarEmail(string email)
      {
         Email emailValido = new Email(email);
         Usuario usuario;
         usuario = repositoryUsuario.ConsultarUsuarioPorEmail(email);

         if (usuario == null)
         {
            return new Response() { Message =  "O usuário não existe no sistema." };
         }
         else
         {
            return new Response() { Message = "Usuario válido."};
         }
      }
   }
}

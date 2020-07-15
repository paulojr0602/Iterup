using Domain.Arguments;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
   public class ServicePessoa : IServicePessoa
   {
      private readonly IRepositoryPessoa repositoryPessoa;
      //Injetando o Repositorio para o Serviço de Pessoa
      public ServicePessoa(IRepositoryPessoa repositoryPessoa)
      {
         this.repositoryPessoa = repositoryPessoa;
      }

      public PessoaResponse CadastrarPessoa(PessoaRequest request)
      {
         if (request == null) { return null; }

         var entidade = new Pessoa(request.Nome, request.CPF, request.UF, request.DataNascimento);
         //Dentro do PessoaResponse existe um método que converte explicitamente para retornar o objeto
         return (PessoaResponse)repositoryPessoa.CadastrarPessoa(entidade);
      }

      public IEnumerable<PessoaResponse> ListarPessoas()
      {
         IEnumerable<Pessoa> configuracoesCollection = repositoryPessoa.ListarPessoas();
         var response = configuracoesCollection.ToList().Select(entidade => (PessoaResponse)entidade);

         return response;
      }

      public PessoaResponse ConsultarPessoaPorId(PessoaRequest request)
      {
         throw new NotImplementedException();
      }

      public PessoaResponse EditarPessoa(PessoaRequest request)
      {
         throw new NotImplementedException();
      }

      public string Excluir(int IdPessoa)
      {
         throw new NotImplementedException();
      }


      public IEnumerable<PessoaResponse> ListarPessoasPorUF()
      {
         throw new NotImplementedException();
      }

      public void Dispose()
      {
         throw new NotImplementedException();
      }
   }
}

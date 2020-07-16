using Domain.Arguments;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
   /// <summary>
   /// Classe de Implementação do Serviço de Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
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
         
         var entidade = new Pessoa(request.Nome, request.Cpf, request.Uf, request.DataNascimento);
         //Dentro do PessoaResponse existe um método que converte explicitamente para retornar o objeto
         return (PessoaResponse)repositoryPessoa.CadastrarPessoa(entidade);
      }

      public IEnumerable<PessoaResponse> ListarPessoas()
      {
         IEnumerable<Pessoa> pessoasCollection = repositoryPessoa.ListarPessoas();
         if (pessoasCollection.Count() == 0) { return null; }
         var response = pessoasCollection.ToList().Select(entidade => (PessoaResponse)entidade);

         return response;
      }

      public PessoaResponse ConsultarPessoaPorId(int id)
      {
         return (PessoaResponse)repositoryPessoa.ConsultarPessoaPorId(id) ;
      }

      public PessoaResponse EditarPessoa(int id, PessoaRequest request)
      {
         //throw new NotImplementedException();
         var entidade = new Pessoa(request.Nome, request.Cpf, request.Uf, request.DataNascimento);
         return (PessoaResponse)repositoryPessoa.EditarPessoa(id, entidade);
      }

      public bool Excluir(int IdPessoa)
      {
         if (!repositoryPessoa.ExcluirPessoa(IdPessoa))
         { 
            return false; 
         }
         return true;
      }

      public IEnumerable<PessoaResponse> ListarPessoasPorUF(string uf)
      {
         IEnumerable<Pessoa> pessoasCollection = repositoryPessoa.ListarPessoasPorUF(uf);
         if (pessoasCollection.Count() == 0) { return null; }
         var response = pessoasCollection.ToList().Select(entidade => (PessoaResponse)entidade);

         return response;
      }

      public IEnumerable<UfResponse> ListarUfs()
      {
         IEnumerable<UF> ufCollection = repositoryPessoa.ListarUfs();
         if(ufCollection.Count() == 0) { return null; }
         var response = ufCollection.ToList().Select(entidade => (UfResponse)entidade);

         return response;
      }
      
   }
}

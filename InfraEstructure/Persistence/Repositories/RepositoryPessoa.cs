using Domain.Entities;
using Domain.Interfaces.IRepository;
using InfraEstructure.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfraEstructure.Persistence.Repositories
{
   /// <summary>
   /// Classe de Repositorio de Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class RepositoryPessoa : IRepositoryPessoa
   {
      private readonly Context context;
      //O contexto é passado por Injeção de Dependência (melhor desacoplamento e manutenção do código)
      public RepositoryPessoa(Context context)
      {
         this.context = context;
      }

      public Pessoa CadastrarPessoa(Pessoa pessoa)
      {
         try
         {
         //Verifica se p CPF já foi cadastrado para um Pessoa.
         if (context.Pessoas.Count() > 0) { 
            if (Existe(pessoa.CPF)){
               throw new Exception("Pessoa já cadastrada para esse CPF.");
            }
         }
         //Adiciona a Pessoa no Contexto caso esteja tudo ok.
         context.Pessoas.Add(pessoa);
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
         return pessoa;
      }

      public bool Existe(string cpf){
         try
         {
            if (context.Pessoas.FirstOrDefault(x => x.CPF == cpf) == null)
            {
               return false;
            }
            return true;
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public Pessoa ConsultarPessoaPorId(int Id)
      {
         return context.Pessoas.FirstOrDefault(x => x.Id == Id);
      }

      public IEnumerable<Pessoa> ConsultarPessoaPorUF(string uf)
      {
         return context.Pessoas.Where(x => x.Uf.Sigla == uf).ToList();
      }

      public Pessoa EditarPessoa(Pessoa pessoa)
      {
         try
         {
            if (Existe(pessoa.CPF))
            {
               var pessoaBD = context.Pessoas.Where(p => p.CPF == pessoa.CPF).FirstOrDefault();

               if (pessoaBD != null)
               {
                  var _pessoa = new Pessoa(pessoaBD.Id,pessoa.Nome, pessoa.CPF, pessoa.Uf, pessoa.DataNascimento);
                  context.Pessoas.Remove(pessoaBD);
                  context.Pessoas.Add(_pessoa);
               }
            }
            else
            {
               throw new Exception("Houve um problema ao tentar encontrar o registro. Verifique.");
            }
            return pessoa;
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public bool ExcluirPessoa(int Id)
      {
         var _pessoa = ConsultarPessoaPorId(Id);
         if (_pessoa == null){
            throw new Exception("Registro inexistente para esse Id.");
         }
         context.Pessoas.Remove(_pessoa);
         return true;
      }

      public IEnumerable<Pessoa> ListarPessoas()
      {
         if (context.Pessoas.Count() == 0)
         {
            throw new Exception("Não existe Pessoa cadastrada.");
         }
         return context.Pessoas.ToList();
      }

   }
}

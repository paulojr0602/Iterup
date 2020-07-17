using Domain.Entities;
using Domain.Extensions;
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
      private UF uF;
      private readonly Context context;
      //O contexto é passado por Injeção de Dependência (melhor desacoplamento e manutenção do código)
      public RepositoryPessoa(Context context)
      {
         this.context = context;
         CarregarUFs();
      }

      public Pessoa CadastrarPessoa(Pessoa pessoa)
      {
         try
         {
         //Verifica se p CPF já foi cadastrado para um Pessoa.
         if (context.Pessoas.Count() > 0) { 
            if (Existe(pessoa.CPF)){
               return null;
            }
         }
         //Buscando a entidade UF 
         var _uf = ConsultarUfPorId(pessoa.IdUf);
         pessoa.Uf = _uf;
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
         var pessoa = context.Pessoas.FirstOrDefault(x => x.Id == Id);
         if(pessoa != null)
         { 
            pessoa.Uf = ConsultarUfPorId(pessoa.IdUf);
            return pessoa;
         }
         return null;
      }

      public Pessoa ConsultarPessoaPorCpf(string cpf)
      {
         var pessoa = context.Pessoas.FirstOrDefault(x => x.CPF == cpf);
         if (pessoa != null)
         {
            pessoa.Uf = ConsultarUfPorId(pessoa.IdUf);
            return pessoa;
         }
         return null;
      }

      public Pessoa ConsultarPessoaPorCpfSenha(string cpf, string senha)
      {
         var pessoa = context.Pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha.ConvertToMD5());
         if (pessoa != null)
         {
            pessoa.Uf = ConsultarUfPorId(pessoa.IdUf);
            return pessoa;
         }
         return null;
      }


      public IEnumerable<Pessoa> ListarPessoasPorUF(string uf)
      {
         foreach (Pessoa pessoa in context.Pessoas)
         {
            pessoa.Uf = ConsultarUfPorId(pessoa.IdUf);
         }
         return context.Pessoas.Where(x => x.Uf.Sigla == uf).ToList();
      }

      public Pessoa EditarPessoa(int id, string nome, string cpf, int idUf, string dataNascimento, string senha)
      {
         var pessoaBD = ConsultarPessoaPorId(id);
         if (pessoaBD != null)
         {
            //Buscando a entidade UF Caso tenha informado a Sigla ("GO" por exemplo)
            UF _uf = ConsultarUfPorId(idUf);
            var pessoaEditada = new Pessoa(id, nome, cpf, _uf, dataNascimento,senha);

            context.Pessoas.Remove(pessoaBD);
            context.Pessoas.Add(pessoaEditada);
            return pessoaEditada;
         } else{
            return null;
         }
      }

      public bool ExcluirPessoa(int Id)
      {
         var _pessoa = ConsultarPessoaPorId(Id);
         if (_pessoa == null){
            return false;
         }
         context.Pessoas.Remove(_pessoa);
         context.SaveChanges();
         return true;
      }

      public IEnumerable<Pessoa> ListarPessoas()
      {
         if (context.Pessoas.Count() == 0)
         {
            return null;
         }

         foreach (Pessoa pessoa in context.Pessoas )
         {
            pessoa.Uf = ConsultarUfPorId(pessoa.IdUf);
         }

         return context.Pessoas.ToList();
      }

#region "Operações da UF"     

      private void CarregarUFs()
      {
         if (context.Ufs.Count() == 0 ) { 
            context.Ufs.Add(new UF("AM", "Amazonas"));
            context.Ufs.Add(new UF("BA", "Bahia"));
            context.Ufs.Add(new UF("CE", "Ceará"));
            context.Ufs.Add(new UF("DF", "Distrito Federal"));
            context.Ufs.Add(new UF("ES", "Espírito Santo"));
            context.Ufs.Add(new UF("GO", "Goiás"));
            context.Ufs.Add(new UF("MG", "Minas Gerais"));
            context.Ufs.Add(new UF("PA", "Pará"));
            context.Ufs.Add(new UF("PE", "Pernambuco"));
            context.Ufs.Add(new UF("SP", "São Paulo"));
            context.SaveChanges();
         }
      }

      public IEnumerable<UF> ListarUfs()
      {
         return context.Ufs.ToList();
      }

      public UF ConsultarUfPorSigla(string sigla)
      {
         return context.Ufs.FirstOrDefault(x => x.Sigla == sigla);
      }

      public UF ConsultarUfPorId(int IdUf)
      {
         return context.Ufs.FirstOrDefault(x => x.Id == IdUf);
      }

#endregion

   }
}

using Domain.Arguments;
using Domain.Entities;
using Domain.Interfaces.IServices.Base;
using System.Collections.Generic;

namespace Domain.Interfaces.IServices
{
   /// <summary>
   /// Interface de Serviço de Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public interface IServicePessoa
   {
      PessoaResponse CadastrarPessoa(PessoaRequest request);
      PessoaResponse ConsultarPessoaPorId(int id);
      IEnumerable<PessoaResponse> ListarPessoas();
      IEnumerable<PessoaResponse> ListarPessoasPorUF(string uf);
      IEnumerable<UfResponse> ListarUfs();
      PessoaResponse EditarPessoa(int id, PessoaRequest request);
      bool Excluir(int IdPessoa);
   }
}

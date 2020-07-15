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
      PessoaResponse ConsultarPessoaPorId(PessoaRequest request);
      IEnumerable<PessoaResponse> ListarPessoas();
      IEnumerable<PessoaResponse> ListarPessoasPorUF();
      IEnumerable<UfResponse> ListarUfs();
      PessoaResponse EditarPessoa(PessoaRequest request);
      string Excluir(int IdPessoa);
   }
}

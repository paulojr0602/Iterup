using Domain.Arguments;
using Domain.Interfaces.IServices.Base;
using System.Collections.Generic;

namespace Domain.Interfaces.IServices
{
   public interface IServicePessoa : IServiceBase
   {
      PessoaResponse CadastrarPessoa(PessoaRequest request);
      PessoaResponse ConsultarPessoaPorId(PessoaRequest request);
      IEnumerable<PessoaResponse> ListarPessoas();
      IEnumerable<PessoaResponse> ListarPessoasPorUF();
      PessoaResponse EditarPessoa(PessoaRequest request);
      string Excluir(int IdPessoa);
   }
}

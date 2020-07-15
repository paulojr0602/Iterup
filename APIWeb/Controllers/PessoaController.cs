using System;
using System.Threading.Tasks;
using Domain.Arguments;
using Domain.Interfaces.IServices;
using InfraEstructure.Persistence.Transactions;
using Microsoft.AspNetCore.Mvc;


namespace APIWeb.Controllers
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Classe Controller de Pessoas
   /// Ações da API para objeto Pessoa (Get,Post, Put, Delete)
   /// </summary>
   [Route("api/[controller]")]
   [ApiController]
   public class PessoaController : Base.ControllerBase
   {
      private readonly IServicePessoa _servicePessoa;

      public PessoaController(IUnitOfWork unitOfWork, IServicePessoa servicePessoa): base(unitOfWork)
      {
         _servicePessoa = servicePessoa;
      }

      // GET api/pessoa/listarpessoas
      [HttpGet("listarpessoas")]
      public async Task<IActionResult> ListarPessoas()
      {
         try
         {
            var response = _servicePessoa.ListarPessoas();
            if (response != null)
            {
               return await ResponseAsync(response);
            }
            return CreatedAtAction("ListarPessoas", new { mensagem = "Ocorreu um erro na consulta." });
         }
         catch (Exception ex)
         {
            return await ResponseExceptionAsync(ex);
         }
      }
            
      // GET api/pessoa/buscarpessoa
      [HttpGet("buscarpessoa/{id}")]
      public ActionResult<string> BuscarPessoa(int id)
      {
         return "value";
      }

      // POST api/pessoa/cadastrarpessoa
      [HttpPost("cadastrarpessoa")]
      public async Task<IActionResult> CadastrarPessoa([FromBody] PessoaRequest request)
      {
         try
         {
            PessoaResponse response = _servicePessoa.CadastrarPessoa(request);
            if(response != null)
            {
               return await ResponseAsync(response);
            }
            return CreatedAtAction("CadastrarPessoa", new { mensagem = "Ocorreu um erro ao tentar cadastrar a pessoa. Verifique." });
         }
         catch (Exception ex)
         {
            return await ResponseExceptionAsync(ex);
         }
      }

      // PUT api/pessoa/alterarpessoa
      [HttpPut("alterarpessoa/{id}")]
      public void EditarPessoa(int id, [FromBody] string value)
      {
      }

      // DELETE api/pessoa/excluirpessoa
      [HttpDelete("excluirpessoa/{id}")]
      public void ExcluirPessoa(int id)
      {
      }

      // GET api/pessoa/listarufs
      [HttpGet("listarufs")]
      public async Task<IActionResult> ListarUfs()
      {
         try
         {
            var response = _servicePessoa.ListarUfs();
            if (response != null)
            {
               return await ResponseAsync(response);
            }
            return CreatedAtAction("ListarUfs", new { mensagem = "Ocorreu um erro na consulta." });
         }
         catch (Exception ex)
         {
            return await ResponseExceptionAsync(ex);
         }
      }
   }
}
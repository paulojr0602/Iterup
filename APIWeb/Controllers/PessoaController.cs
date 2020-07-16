using System;
using System.Net;
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
   [Route("api/pessoas")]
   [ApiController]
   public class PessoaController : Base.ControllerBase
   {
      private readonly IServicePessoa _servicePessoa;

      public PessoaController(IUnitOfWork unitOfWork, IServicePessoa servicePessoa): base(unitOfWork)
      {
         _servicePessoa = servicePessoa;
      }

      // GET api/pessoas
      [HttpGet()]
      public async Task<IActionResult> Get()
      {
         var response = _servicePessoa.ListarPessoas();
         if (response != null)
         {
            return await ResponseAsync(response);
         } else {
            return CreatedAtAction("Get", new { HttpStatusCode.NoContent });
         }
      }

      // GET api/pessoas/id
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var response = _servicePessoa.ConsultarPessoaPorId(id);
         if (response.CPF != null)
         {
            return await ResponseAsync(response);
         }
         else {
            return CreatedAtAction("Get", new { HttpStatusCode.NoContent });
         }
      }

      // GET api/pessoas/uf?uf
      [HttpGet("uf/{uf}")]
      public async Task<IActionResult> Get(string uf)
      {
         var response = _servicePessoa.ListarPessoasPorUF(uf);
         if (response != null)
         {
            return await ResponseAsync(response);
         }
         else
         {
            return CreatedAtAction("Get", new { HttpStatusCode.NoContent });
         }
      }

      // POST api/pessoas
      [HttpPost()]
      public async Task<IActionResult> Post([FromBody] PessoaRequest request)
      {
         PessoaResponse response = _servicePessoa.CadastrarPessoa(request);
         if(response != null)
         {
            return await ResponseAsync(response);
         } else {
            return CreatedAtAction("Post", new { HttpStatusCode.BadRequest });
         }
      }

      // PUT api/pessoas/id
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] PessoaRequest request)
      {
         var response = _servicePessoa.EditarPessoa(id, request);
         if (response != null)
         {
            return await ResponseAsync(response);
         } else {
            return CreatedAtAction("Put", new { HttpStatusCode.BadRequest });
         }
      }

      // DELETE api/pessoas/id
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var response = _servicePessoa.Excluir(id);
         if (!response)
         {
            return  CreatedAtAction("Put", new { HttpStatusCode.BadRequest });
         }
         return CreatedAtAction("Put", new { HttpStatusCode.OK });
      }

      // GET api/pessoas/ufs
      [HttpGet("ufs")]
      public async Task<IActionResult> GetUfs()
      {
         var response = _servicePessoa.ListarUfs();
         if (response != null)
         {
            return await ResponseAsync(response);
         }
         return CreatedAtAction("GetUfs", new { HttpStatusCode.NoContent });
      }
   }
}
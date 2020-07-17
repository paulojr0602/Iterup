using APIWeb.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Domain.Arguments;
using Domain.Interfaces.IServices;
using InfraEstructure.Persistence.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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
      private readonly IHttpContextAccessor _httpContextAccessor;


      public PessoaController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IServicePessoa servicePessoa): base(unitOfWork)
      {
         _httpContextAccessor = httpContextAccessor;
         _servicePessoa = servicePessoa;
      }

      // GET api/pessoas
      [AllowAnonymous]
      [HttpGet]
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
         string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
         var pessoaResponse = JsonConvert.DeserializeObject<UsuarioAutenticadoResponse>(usuarioClaims);

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
      [AllowAnonymous]
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] PessoaRequest request)
      {
         try
         {
            PessoaResponse response = _servicePessoa.CadastrarPessoa(request);
            if(response.CPF != null)
            {
            
               return await ResponseAsync(response);
            } else {
               return CreatedAtAction("Post", new { HttpStatusCode.BadRequest });
            }
         }
         catch (Exception ex)
         {
            return CreatedAtAction("Post", new { HttpStatusCode.BadRequest }); ;
         }
      }

      // POST api/pessoas/login
      [AllowAnonymous]
      [HttpPost("login")]
      public object PostLogin([FromBody] UsuarioRequest request,
                        [FromServices]SigningConfigurations signingConfigurations,
                        [FromServices]TokenConfigurations tokenConfigurations)
      {
         UsuarioAutenticadoResponse response = _servicePessoa.AutenticarPessoa(request.Cpf, request.Senha);
         if (response.Cpf != null)
         {
            ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(response.Id.ToString(), "Id"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        //new Claim(JwtRegisteredClaimNames.UniqueName, response.Usuario)
                        new Claim("Usuario", JsonConvert.SerializeObject(response))
                   }
            );

            //Criando a identidade e configuração do Token da API
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
            TimeSpan.FromSeconds(tokenConfigurations.Seconds);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
               Issuer = tokenConfigurations.Issuer,
               Audience = tokenConfigurations.Audience,
               SigningCredentials = signingConfigurations.SigningCredentials,
               Subject = identity,
               NotBefore = dataCriacao,
               Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
               authenticated = true,
               created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
               expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
               accessToken = token,
               message = "Usuário logado",
               Nome = response.Nome,
               CPF = response.Cpf,
               id = response.Id
            };
         }
         else
         {
            // return CreatedAtAction("Post", new { HttpStatusCode.BadRequest });
            return new
            {
               authenticated = false,
               message = "cpf ou senha inválidos."
            };
         }
      }

      // PUT api/pessoas/id
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] PessoaRequest request)
      {
         //Verifica se o usuário está logado e se possui token
         string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
         var pessoaResponse = JsonConvert.DeserializeObject<UsuarioAutenticadoResponse>(usuarioClaims);

         PessoaResponse response = _servicePessoa.EditarPessoa(id, request);
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
         //Verifica se o usuário está logado e se possui token
         string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
         var pessoaResponse = JsonConvert.DeserializeObject<UsuarioAutenticadoResponse>(usuarioClaims);

         var response = _servicePessoa.Excluir(id);
         if (!response)
         {
            return  CreatedAtAction("Put", new { HttpStatusCode.BadRequest });
         }
         return CreatedAtAction("Put", new { HttpStatusCode.OK });
      }

      // GET api/pessoas/ufs
      [AllowAnonymous]
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
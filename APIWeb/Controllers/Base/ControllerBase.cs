using Domain.Interfaces.IServices.Base;
using InfraEstructure.Persistence.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIWeb.Controllers.Base
{
   /// <summary>
   /// Classe de Apoio para o Controlador
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class ControllerBase : Controller
   {
      //Infraestrutura.Transacoes 
      private readonly IUnitOfWork _unitOfWork;

      public ControllerBase(IUnitOfWork unitOfWork)
      {
         _unitOfWork = unitOfWork;
      }

      public async Task<IActionResult> ResponseAsync(object result)
      {
         if (result != null)
         {
            try
            {
               _unitOfWork.Commit();

               return Ok(result);
            }
            catch (Exception ex)
            {
               // Aqui devo logar o erro
               return BadRequest($"Houve uma falha com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
         }
         else
         {
            return BadRequest($"Ocorreu um erro inesperado ao tentar gravar. Entre em contato com o Administrador do sistema caso o problema persista.");
         }
      }

      public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
      {
         return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
      }

      protected override void Dispose(bool disposing)
      {
         //Realiza o dispose no serviço para que possa ser zerada as notificações
         base.Dispose(disposing);
      }
   }
}

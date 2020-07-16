using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Arguments
{
/// <summary>
/// Classe de Response de UF
/// Autor: Paulo Roberto de Almeida Jr. Data:15/07/2020
/// </summary>
   public class UfResponse
   {
      public int Id { get; set; }
      public string sigla { get; set; }
      public string estado { get; set; }

      public static explicit operator UfResponse(UF entidade)
      {
         return new UfResponse()
         {
            Id = entidade.Id,
            sigla = entidade.Sigla,
            estado = entidade.Estado
         };
      }
   }
}

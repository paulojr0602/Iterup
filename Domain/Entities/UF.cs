using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   /// <summary>
   /// Classe de Entidade UF
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class UF: EntityBase
   {
      public UF(string sigla)
      {
         if (ValidarTextoSigla(sigla)) { Sigla = sigla; }
      }

      public string Sigla { get; private set; }

      public static bool ValidarTextoSigla(string sigla)
      {
         return String.IsNullOrWhiteSpace(sigla) ? throw new ArgumentNullException(nameof(sigla), $"{nameof(sigla)} parâmetro obrigatório") : true;
      }
   }
}

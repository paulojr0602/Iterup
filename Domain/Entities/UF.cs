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

      public UF(int Id, string sigla, string estado)
      {
         this.Id = Id;
         if (ValidarTextoSigla(sigla)) { Sigla = sigla; }
         if (String.IsNullOrWhiteSpace(estado)) { Estado = ""; } else { Estado = estado; }

      }
      public UF( string sigla, string estado)
      {
         if (ValidarTextoSigla(sigla)) { Sigla = sigla; }
         if (String.IsNullOrWhiteSpace(estado)) { Estado = ""; } else { Estado = estado; }
      }

      public string Sigla { get; private set; }
      public string Estado { get; private set; }

      public static bool ValidarTextoSigla(string sigla)
      {
         return String.IsNullOrWhiteSpace(sigla) ? throw new ArgumentNullException(nameof(sigla), $"{nameof(sigla)} parâmetro obrigatório") : true;
      }
      public static bool ValidarTextoEstado(string estado)
      {
         return String.IsNullOrWhiteSpace(estado) ? throw new ArgumentNullException(nameof(estado), $"{nameof(estado)} parâmetro obrigatório") : true;
      }
   }
}

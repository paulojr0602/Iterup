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
      
      public UF( string sigla, string estado)
      {
         Sigla = sigla;          
         Estado = estado; 
      }

      public string Sigla { get; private set; }
      public string Estado { get; private set; }
           
   }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjectValue
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Classe de Obejto de Valor de Nome de Usuario
   /// </summary>
   public class NomeDeUsuario
   {
      public NomeDeUsuario(string primeiroNome, string ultimoNome)
      {
         PrimeiroNome = primeiroNome ?? throw new ArgumentNullException(nameof(primeiroNome));
         UltimoNome = ultimoNome ?? throw new ArgumentNullException(nameof(ultimoNome));
      }

      public string PrimeiroNome { get; private set; }
      public string UltimoNome { get; private set; }
   }
}

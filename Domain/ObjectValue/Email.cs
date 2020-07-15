using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjectValue
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Classe de Objeto de valor de Email
   /// </summary>
   public class Email
   {
      public Email(string enderecoEletronico)
      {
         EnderecoEletronico = enderecoEletronico ?? throw new ArgumentNullException(nameof(enderecoEletronico));
      }

      public string EnderecoEletronico { get; private set; }
   }
}

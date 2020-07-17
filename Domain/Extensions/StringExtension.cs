using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
   /// <summary>
   /// Classe StringExtension responsável por converter a senha de string para MD5.
   /// Autor: Paulo Roberto de Almeida Jr. Data:16/07/2020.
   /// </summary>
   public static class StringExtension
   {
      public static string ConvertToMD5(this string text)
      {
         if (string.IsNullOrEmpty(text)) return "";
         var password = (text += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
         var md5 = System.Security.Cryptography.MD5.Create();
         var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
         var sbString = new StringBuilder();
         foreach (var t in data)
            sbString.Append(t.ToString("x2"));

         return sbString.ToString();
      }
   }
}

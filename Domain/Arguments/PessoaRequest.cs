using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Arguntos de Pessoa Request
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class PessoaRequest
   {
      public PessoaRequest(string nome, string cpf, string dataNascimento, string idUf, string senha)
      {
         Nome = nome;
         Cpf = cpf;
         DataNascimento = "xxxxxxxxxxxx";
         if( ValidarData(dataNascimento)){ DataNascimento = dataNascimento; }
         if (!String.IsNullOrWhiteSpace(idUf)) { idUF = Convert.ToInt32(idUf); }
         Senha = senha;
      }

      [Required]
      [StringLength(50, ErrorMessage = "Permitido até 50 caracteres.")]
      public string Nome { get; set; }

      [Required]
      [StringLength(50, ErrorMessage = "Permitido até 50 caracteres.")]
      public string Senha { get; set; }

      [Required]
      [StringLength(14, ErrorMessage = "Permitido 11 caracteres sem ponto ou 14 caracteres com pontos.")]
      public string Cpf { get; set; }

      [Required]
      [StringLength(10, ErrorMessage = "Data inválida (dd/MM/aaaa).")]
      public string DataNascimento { get; set; }

      [Required]
      [Range(1, 26, ErrorMessage = "Informar o número do IdUf.")]
      public int idUF { get; set; }

      public bool ValidarData(string data)
      {
         if (data != "" && (data.Length < 10))
         {
            return false;
         }
         string dia, mes, ano;
         string aux;
         aux = data;

         dia = aux.Substring(0, 2);
         mes = aux.Substring(3, 2);
         ano = aux.Substring(6, 4);


         if (dia != "01" && dia != "02" && dia != "03" && dia != "04" && dia != "05" && dia != "06"
             && dia != "07" && dia != "08" && dia != "09" && dia != "10" && dia != "11" && dia != "12"
             && dia != "13" && dia != "14" && dia != "15" && dia != "16" && dia != "17" && dia != "18"
             && dia != "19" && dia != "20" && dia != "21" && dia != "22" && dia != "23" && dia != "24"
             && dia != "25" && dia != "26" && dia != "27" && dia != "28" && dia != "29" && dia != "30"
             && dia != "31")
         {

            return false;
         }
         if (mes != "01" && mes != "02" && mes != "03" && mes != "04" && mes != "05" && mes != "06"
             && mes != "07" && mes != "08" && mes != "09" && mes != "10" && mes != "11" && mes != "12")
         {

            return false;
         }
         if ((dia == "29") && (mes == "02"))
         {
            if (!(Convert.ToInt32(ano) % 4 == 0) && (Convert.ToInt32(ano) % 100 != 0))
            {
               return false;
            }
         }
         return true;
      }

   }
}

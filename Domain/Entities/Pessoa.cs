using Domain.Arguments;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
   /// <summary>
   /// Classe de Entidade Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Responsável por criar o objeto e se autovalidar
   /// </summary>
   public class Pessoa : EntityBase
   {
      public Pessoa(string _Nome, string _cpf, string _uf, string _dataNascimento)
      {
         if (ValidarNome(_Nome)) { Nome = _Nome; }
         if (ValidarTextoCPF(_cpf)){ CPF = _cpf;  }
         if (!ValidarCpf(CPF)) { throw new Exception("O CPF informado é inválido!"); }
         DataNascimento = ValidarData(_dataNascimento);
         if (ValidarTextoUF(_uf)) { Uf = new UF(_uf, ""); }
      }

      public Pessoa(int Id, string nome, string cPF, UF uF, string _dataNascimento)
      {
         this.Id = Id;
         Nome = nome;
         CPF = cPF;
         Uf = uF;
         DataNascimento = ValidarData(_dataNascimento);
      }
            
      protected Pessoa()
      { 
      }

      public string Nome { get; private set; }
      public string CPF { get; private set; }
      public string DataNascimento { get; private set; }
      public int IdUf { get; set; }
      public UF Uf { get; set; }

      #region "Validações da Classe"

      public static bool ValidarNome(string nome)
      {
        return String.IsNullOrWhiteSpace(nome) ? throw new ArgumentNullException(nameof(nome), $"{nameof(Nome)} parâmetro obrigatório") : true;
      }

      public static bool ValidarTextoCPF(string _CPF)
      {
         return String.IsNullOrWhiteSpace(_CPF) ? throw new ArgumentNullException(nameof(_CPF), $"{nameof(CPF)} parâmetro obrigatório") : true;
      }

      public static bool ValidarTextoUF(string _UF)
      {
         return String.IsNullOrWhiteSpace(_UF) ? throw new ArgumentNullException(nameof(_UF), $"{nameof(UF)} Informe a sigla ou o Id da UF") : true;
      }

      public static bool ValidarCpf(string cpf)
      {
         int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
         int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
         string tempCpf;
         string digito;
         int soma;
         int resto;
         cpf = cpf.Trim();
         cpf = cpf.Replace(".", "").Replace("-", "");
         if (cpf.Length != 11)
            return false;
         tempCpf = cpf.Substring(0, 9);
         soma = 0;

         for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
         resto = soma % 11;
         if (resto < 2)
            resto = 0;
         else
            resto = 11 - resto;
         digito = resto.ToString();
         tempCpf = tempCpf + digito;
         soma = 0;
         for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
         resto = soma % 11;
         if (resto < 2)
            resto = 0;
         else
            resto = 11 - resto;
         digito = digito + resto.ToString();
         return cpf.EndsWith(digito);
      }

      public static string ValidarData(string data){
         string hora = "01:00:00";
         try
         {
            return (data + " " + hora);
         }
         catch (FormatException ex)
         {
            throw new FormatException(ex.Message);
         }
      }
   }
#endregion
}

using Domain.Arguments;
using Domain.Entities.Base;
using Domain.Extensions;
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
      public Pessoa(string _Nome, string _cpf, int _idUf, string _dataNascimento, string _senha)
      {
         Nome = _Nome; 
         CPF = _cpf;  
         DataNascimento = ValidarData(_dataNascimento);
         IdUf = _idUf; 
         Senha = _senha; 

         //Conversão da senha para Criptografia MD5;
         Senha = Senha.ConvertToMD5();

      }

      public Pessoa(int Id, string nome, string cPF, UF uF, string _dataNascimento, string senha)
      {
         this.Id = Id;
         Nome = nome;
         CPF = cPF;
         Uf = uF;
         IdUf = uF.Id;
         DataNascimento = ValidarData(_dataNascimento);
         Senha = senha;
         Senha = Senha.ConvertToMD5();
      }

      protected Pessoa()
      { 
      }

      public string Nome { get; private set; }
      public string Senha { get; private set; }
      public string CPF { get; private set; }
      public string DataNascimento { get; private set; }
      public int IdUf { get; set; }

      public UF Uf { get; set; }

      #region "Validações da Classe"
           
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

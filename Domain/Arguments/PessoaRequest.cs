namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Arguntos de Pessoa Request
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class PessoaRequest
   {
      public PessoaRequest(string nome,  string cPF, string uF, string dataNascimento)
      {
         Nome = nome;
         CPF = cPF;
         UF = uF;
         DataNascimento = dataNascimento;
      }

      public string Nome { get; private set; }
      public string CPF { get; private set; }
      public string UF { get; private set; }
      public string DataNascimento { get; private set; }
   }
}

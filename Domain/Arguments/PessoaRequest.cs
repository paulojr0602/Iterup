namespace Domain.Arguments
{
   /// <summary>
   /// Classe de Arguntos de Pessoa Request
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class PessoaRequest
   {
      public PessoaRequest(string nome,  string cpf,  string dataNascimento, string uf)
      {
         Nome = nome;
         Cpf = cpf;
         Uf = uf;
         DataNascimento = dataNascimento;
      }
      

      public string Nome { get; private set; }
      public string Cpf { get; private set; }
      public string DataNascimento { get; private set; }
      public string Uf { get;  set; }
   }
}

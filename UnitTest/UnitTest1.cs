using Domain.Arguments;
using Domain.Interfaces.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTest
{
   [TestClass]
   public class UnitTest1
   {

      private Domain.Entities.Pessoa _pessoa;
      public IServicePessoa _servicePessoa;
      public PessoaRequest request;

      [TestMethod]
      public void TestMethod1(IServicePessoa servicePessoa)
      {
         //Teste Unitário
         //_pessoa = new Domain.Entities.Pessoa("Almeida", "11040128637", "GO", "01/01/2000");

         //Teste de CRUD
         request = new PessoaRequest("Paulo", "11040128637",  "01/01/2000", "GO");
         _servicePessoa =  servicePessoa;
         PessoaResponse response = _servicePessoa.CadastrarPessoa(request);
         if (response == null) { throw new Exception("Erro"); }
      }
   }
}

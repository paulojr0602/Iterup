﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IRepository
{
   /// <summary>
   /// Interface de Repositório de Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public interface IRepositoryPessoa
   {
      Pessoa ConsultarPessoaPorId(int id);
      IEnumerable<Pessoa> ListarPessoasPorUF(string uf);
      IEnumerable<Pessoa> ListarPessoas();
      IEnumerable<UF> ListarUfs();
      Pessoa CadastrarPessoa(Pessoa pessoa);
      Pessoa EditarPessoa(int id, string nome, string cpf, int idUf, string dataNascimento, string senha);
      bool ExcluirPessoa(int id);
      Pessoa ConsultarPessoaPorCpfSenha(string cpf, string senha);
      Pessoa ConsultarPessoaPorCpf(string cpf);
   }
}

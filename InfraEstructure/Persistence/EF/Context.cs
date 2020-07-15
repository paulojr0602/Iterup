using Domain.Entities;
using InfraEstructure.Persistence.EF.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.EF
{
   /// <summary>
   /// Classe de Contexto da Aplicação
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// O contexto de banco de dados é a classe principal que coordena a funcionalidade do Entity Framework para um modelo de dados
   /// Responsável por mapear o banco de dados. Neste caso está para o modo desenvolvedor( InMemory)
   /// </summary>
   public class Context : DbContext
   {

      public DbSet<Pessoa> Pessoas { get; set; }
      public DbSet<UF> Ufs { get; set; }

      
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseInMemoryDatabase();

         //base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         //ignorar classes que não devem ser geradas
         //modelBuilder.Ignore<Classe>();
         
         //aplicar configurações
         modelBuilder.ApplyConfiguration(new MapPessoa());

         base.OnModelCreating(modelBuilder);
      }
   }
} 

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.EF.Map
{
   /// <summary>
   /// Classe de Mapeamento de Pessoa
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class MapPessoa : IEntityTypeConfiguration<Pessoa>
   {
      public void Configure(EntityTypeBuilder<Pessoa> builder)
      {
         //Nome da tabela
         builder.ToTable("Pessoa");
         builder.HasIndex(p => p.Id).IsUnique();
         //Chave primária
         builder.HasKey(p => p.Id);
         //Chave estrangeira da tabela Pessoa
         builder.HasOne(p => p.Uf)
                .WithMany()
                .HasForeignKey("IdUf");

         builder.Property(x => x.Nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");
         builder.Property(x => x.Senha).HasMaxLength(50).IsRequired().HasColumnName("Senha");
         builder.Property(x => x.CPF).HasMaxLength(14).IsRequired().HasColumnName("CPF");
         builder.Property(x => x.DataNascimento).HasMaxLength(10).IsRequired().HasColumnName("DataNascimento");
         
      }
   }
}

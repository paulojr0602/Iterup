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
                .WithOne()
                .HasForeignKey<Pessoa>(p => p.IdUf);

         builder.Property(x => x.Nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");
         builder.Property(x => x.CPF).HasMaxLength(11).IsRequired().HasColumnName("CPF");
         builder.Property(x => x.DataNascimento).IsRequired().HasColumnName("DataNascimento");
         //builder.Property(u => u.IdUf).IsRequired().HasColumnName("IdUF");

         //builder.OwnsOne<UF>(p => p.Uf, u =>
         //{
         //   u.Property(s => s.Sigla).IsRequired();
         //   u.Property(e => e.Estado).IsRequired();
         //   u.Property(i => i.Id).IsRequired();
         //});


      }
   }
}

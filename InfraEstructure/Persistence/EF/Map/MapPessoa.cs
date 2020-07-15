using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.EF.Map
{
   public class MapPessoa : IEntityTypeConfiguration<Pessoa>
   {
      public void Configure(EntityTypeBuilder<Pessoa> builder)
      {
         //Nome da tabela
         builder.ToTable("Pessoa");
         builder.HasIndex(u => u.Id).IsUnique();
         //Chave primária
         builder.HasKey(x => x.Id);

         builder.Property(x => x.Nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");
         builder.Property(x => x.CPF).HasMaxLength(11).IsRequired().HasColumnName("CPF");
         builder.Property(x => x.IdUf).IsRequired().HasColumnName("IdUF");
         builder.Property(x => x.DataNascimento).IsRequired().HasColumnName("DataNascimento");

      }
   }
}

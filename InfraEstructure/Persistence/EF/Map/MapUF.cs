using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.EF.Map
{
   /// <summary>
   /// Classe de Map da UF
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// </summary>
   public class MapUF
   {
      public void Configure(EntityTypeBuilder<UF> builder)
      {
         //Nome da tabela
         builder.ToTable("UF");
         builder.HasIndex(u => u.Id).IsUnique();
         //Chave primária
         builder.HasKey(x => x.Id);

         builder.Property(x => x.Sigla).HasMaxLength(50).IsRequired().HasColumnName("Sigla");
         builder.Property(x => x.Estado).HasMaxLength(11).IsRequired().HasColumnName("Estado");
      }
   }
}

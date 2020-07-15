using InfraEstructure.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.Transactions
{
   /// <summary>
   /// Implementação da Interface IUnitOfWork
   /// Autor: Paulo Roberto de Almeida Jr. Data: 14/07/2020
   /// </summary>
   public class UnitOfWork : IUnitOfWork
   {
      private readonly Context _context;

      public UnitOfWork(Context context)
      {
         _context = context;
      }

      public void Commit()
      {
         _context.SaveChanges();
      }
   }
}

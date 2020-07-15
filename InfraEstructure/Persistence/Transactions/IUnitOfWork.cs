using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence.Transactions
{
   /// <summary>
   /// Interface de UnitOfWork
   /// Autor: Paulo Roberto de Almeida Jr. Data: 14/07/2020
   /// </summary>
   public interface IUnitOfWork
   {
      void Commit();
   }
}

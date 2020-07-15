using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IServices.Base
{
   /// <summary>
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Esta Interface foi criada para garantir as notificações para as classes 
   /// que a herdarem. Apenas como forma de organização. Tudo que herdar de 
   /// IServiceBase será Notificável.
   /// </summary>
   public interface IServiceBase: IDisposable
   {
   }
}

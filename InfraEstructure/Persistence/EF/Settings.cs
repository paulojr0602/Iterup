using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstructure.Persistence
{
   public abstract class Settings
   {
      public static string APITest = @"Server=DESKTOP-L38SE3K\SQLEXPRESS;Database=Iterup;Trusted_Connection=True;ConnectRetryCount=0;";
   }
}

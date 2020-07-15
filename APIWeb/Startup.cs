using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Services;
using InfraEstructure.Persistence.EF;
using InfraEstructure.Persistence.Repositories;
using InfraEstructure.Persistence.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIWeb
{
   /// <summary>
   /// Classe Startup da API.
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Responsável por receber as configurações de Injeção de Denpendência e Sistemas de Autenticação entre outras configurações.
   /// </summary>
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

         services.AddHttpContextAccessor();

         //Adiciona a injeção de dependencia do Contexto do EF
         services.AddScoped<Context, Context>();

         services.AddTransient<IUnitOfWork, UnitOfWork>();
         
         //Services
         services.AddTransient<IServicePessoa, ServicePessoa>();
         services.AddTransient<IServiceUsuario, ServiceUsuario>();

         //Repositories
         services.AddTransient<IRepositoryPessoa, RepositoryPessoa>();
         //services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseHsts();
         }

         app.UseHttpsRedirection();
         app.UseMvc();
      }
   }
}

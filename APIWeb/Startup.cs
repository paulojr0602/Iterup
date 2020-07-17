using APIWeb.Security;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Services;
using InfraEstructure.Persistence.EF;
using InfraEstructure.Persistence.Repositories;
using InfraEstructure.Persistence.Transactions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIWeb
{
   /// <summary>
   /// Classe Startup da API.
   /// Autor: Paulo Roberto de Almeida Jr. Data:14/07/2020
   /// Responsável por receber as configurações de Injeção de Denpendência e Sistemas de Autenticação entre outras configurações.
   /// </summary>
   public class Startup
   {
      private const string ISSUER = "c1f51f42";
      private const string AUDIENCE = "c6bbbb645024";

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         //Adiciona a injeção de dependencia do Contexto do EF
         services.AddScoped<Context, Context>();

         //UnitOfWork
         services.AddTransient<IUnitOfWork, UnitOfWork>();

         //Services
         services.AddTransient<IServicePessoa, ServicePessoa>();

         //Repositories
         services.AddTransient<IRepositoryPessoa, RepositoryPessoa>();

         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

         services.AddHttpContextAccessor();

         #region "Token"

         //Configuração do Token
         var signingConfigurations = new SigningConfigurations();
         services.AddSingleton(signingConfigurations);

         var tokenConfigurations = new TokenConfigurations
         {
            Audience = AUDIENCE,
            Issuer = ISSUER,
            Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())

         };
         services.AddSingleton(tokenConfigurations);


         services.AddAuthentication(authOptions =>
         {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         }).AddJwtBearer(bearerOptions =>
         {
            var paramsValidation = bearerOptions.TokenValidationParameters;
            paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
            paramsValidation.ValidAudience = tokenConfigurations.Audience;
            paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

            // Valida a assinatura de um token recebido
            paramsValidation.ValidateIssuerSigningKey = true;

            // Verifica se um token recebido ainda é válido
            paramsValidation.ValidateLifetime = true;

            // Tempo de tolerância para a expiração de um token (utilizado
            // caso haja problemas de sincronismo de horário entre diferentes
            // computadores envolvidos no processo de comunicação)
            paramsValidation.ClockSkew = TimeSpan.Zero;
         });

         // Ativa o uso do token como forma de autorizar o acesso
         // a recursos deste projeto
         services.AddAuthorization(auth =>
         {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser().Build());
         });

         //Para todas as requisições serem necessaria o token, para um endpoint não exigir o token
         //deve colocar o [AllowAnonymous]
         //Caso remova essa linha, para todas as requisições que precisar de token, deve colocar
         //o atributo [Authorize("Bearer")]
         services.AddMvc(config =>
         {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser().Build();

            config.Filters.Add(new AuthorizeFilter(policy));
         });

         //Para todas as requisições serem necessaria o token, para um endpoint não exigir o token
         //deve colocar o [AllowAnonymous]
         //Caso remova essa linha, para todas as requisições que precisar de token, deve colocar
         //o atributo [Authorize("Bearer")]
         services.AddMvc(config =>
         {
            //Autor: Paulo Roberto de Almeida Jr. Data:16/07/2020
            //Com essa configuração, todos os métodos dos Controllers passam a ser negados
            //Para ter acesso seguro usa-se a notação: [Authorize("Bearer")]
            //Para ser público sem Token usa-se o [AllowAnonymous], permite sem Token 
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser().Build();

            config.Filters.Add(new AuthorizeFilter(policy));
         });

         //Adicionado para trabalhar com a segurança
         services.AddCors();
         #endregion
                  
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

         app.UseCors(x => {
            x.AllowAnyHeader();
            x.AllowAnyMethod();
            x.AllowAnyOrigin();
         });

         //app.UseHttpsRedirection();
         app.UseMvc();
         
      }
   }
}

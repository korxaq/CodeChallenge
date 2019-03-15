using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CodeChallenge.Api.Filters;
using CodeChallenge.Common.JsonConverter;
using CodeChallenge.Common.MagicValues;
using CodeChallenge.Common.Mapping;
using CodeChallenge.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CodeChallenge.Api
{
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
            var connectionString = Configuration.GetConnectionString("PostgresConnectionString");

            services.AddDbContext<CodeChallengeContext>(options => options.UseNpgsql(connectionString, npSqlOptions =>
            {
                npSqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

            services.AddTransient<IMapper, Mapper>();

            var builder = new ContainerBuilder();
            builder.Populate(services);

            AddAutofacRegistrations(builder);

            var container = builder.Build();

            GlobalExceptionFilter globalExceptionFilter;

            using (var scope = container.BeginLifetimeScope())
            {
                globalExceptionFilter = scope.Resolve<GlobalExceptionFilter>();
            }

            var allowedCorsQueryable = Configuration.GetSection(Constants.ALLOWED_ORIGINS).AsEnumerable();

            var allowedCors = allowedCorsQueryable.Where(x => x.Value != null).Select(config => config.Value).ToArray();

            services.AddCors(options => options.AddPolicy(Constants.ALLOW_FROM_CONFIGURED,
                corsBuilder => corsBuilder
                    .WithOrigins(allowedCors)
                    .WithMethods("GET", "POST", "PUT")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()));

            services.AddMvc(mvcOptions => mvcOptions.Filters.Add(globalExceptionFilter)).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            app.UseCors("AllowFromConfigured");

            app.UseAuthentication();

            app.UseHealthChecks("/healthz");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "api/{controller}/{action}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetService<CodeChallengeContext>();
                ctx.DatabaseSetUp().Wait();
            }
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutofacRegistrations(builder);
        }

        private void AddAutofacRegistrations(ContainerBuilder builder)
        {
            #region BLL
            /*builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CreditDebitBll)))
                .Where(t => t.Name.EndsWith("Bll"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(TransactionTypesGateway)))
                .Where(t => t.Name.EndsWith("Gateway"))
                .AsImplementedInterfaces();*/
            #endregion

            #region DAL
            //builder.RegisterType<SkinsFinancialContext>().As<SkinsFinancialContext>().InstancePerLifetimeScope();
            builder.RegisterType<CodeChallengeContext>().As<CodeChallengeContext>().InstancePerLifetimeScope();

            /*builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(SkinsTransactionHistoryRepository)))
                .Where(t => t.Name.Contains("Repository"))
                .AsImplementedInterfaces();*/
            #endregion

            #region COMMON
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<HttpClient>().InstancePerLifetimeScope();
            builder.RegisterType<GlobalExceptionFilter>().SingleInstance().AutoActivate().AsSelf();
            builder.RegisterType<JsonConverter>().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var logger = ctx.Resolve<ILogger<MappingEngine>>();

                IEnumerable<Assembly> assemblies = new[]
                {
                    Assembly.GetExecutingAssembly()
                };
                return new MappingEngine(assemblies, logger);
            }).As<IMappingEngine>().SingleInstance().AutoActivate().AsSelf();
            #endregion
        }
    }
}

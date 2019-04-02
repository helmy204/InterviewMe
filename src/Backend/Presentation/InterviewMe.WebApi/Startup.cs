using Infrastructure.Data.EfMigrationContext;
using InterviewMe.SharedKernel;
using InterviewMe.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestionsManagement.Core.Interfaces;
using QuestionsManagement.Core.Services;
using QuestionsManagement.Data;
using System;

namespace InterviewMe.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();

            services.AddEntityFrameworkSqlServer()
               .AddDbContext<InterviewMeContext>(options =>
                               options.UseSqlServer(Configuration.GetConnectionString("InterviewMeConnection")));

            services.AddScoped<DbContext, InterviewMeContext>();
            services.AddSingleton<DomainEvents>();

            services.AddTransient<IQuestionsRepository, QuestionsRepository>();
            services.AddEntityFrameworkSqlServer()
             .AddDbContext<QuestionsContext>(options =>
                             options.UseSqlServer(Configuration.GetConnectionString("InterviewMeConnection")));
            services.AddTransient<QuestionCreatedHandler>();

            ContainerManager.Container =services.BuildServiceProvider();
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

            app.UseCors(options =>
              options.WithOrigins("*").WithHeaders("*"));

            app.UseHttpsRedirection();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionsManagement.Core.Model.Question, Models.QuestionModel>();
            });


            app.UseMvc(config =>
            {
                config.MapRoute("MainAPIRoute", "api/{controller}/{action}");
            });

        }
    }
}

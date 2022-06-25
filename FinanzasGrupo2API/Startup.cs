﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasGrupo2API.Security.Authorization.Handlers.Implementations;
using FinanzasGrupo2API.Security.Authorization.Handlers.Interfaces;
using FinanzasGrupo2API.Security.Authorization.Middleware;
using FinanzasGrupo2API.Security.Authorization.Settings;
using FinanzasGrupo2API.Security.Domain.Repositories;
using FinanzasGrupo2API.Security.Domain.Services;
using FinanzasGrupo2API.Security.Persistence.Repositories;
using FinanzasGrupo2API.Security.Services;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API
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
            services.AddCors();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("supermarket-api-in-memory");
                options.UseMySQL(Configuration.GetConnectionString("Default"));
            });

            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<SnakeCaseDocumentFilter>();
                c.OperationFilter<SnakeCaseOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanzasGrupo2API", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IJwtHandler, JwtHandler>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For this course purpose we allow Swagger in release mode.
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanzasGrupo2API v1"));

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
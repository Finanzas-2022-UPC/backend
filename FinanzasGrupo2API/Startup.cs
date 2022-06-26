using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasGrupo2API.Bonos.Domain.Repositories;
using FinanzasGrupo2API.Bonos.Domain.Services;
using FinanzasGrupo2API.Bonos.Persistence.Repositories;
using FinanzasGrupo2API.Bonos.Services;
using FinanzasGrupo2API.Cruds.Domain.Repositories;
using FinanzasGrupo2API.Cruds.Domain.Services;
using FinanzasGrupo2API.Cruds.Persistence.Repositories;
using FinanzasGrupo2API.Cruds.Services;
using FinanzasGrupo2API.DataFrancess.Domain.Repositories;
using FinanzasGrupo2API.DataFrancess.Domain.Services;
using FinanzasGrupo2API.DataFrancess.Persistence.Repositories;
using FinanzasGrupo2API.DataFrancess.Services;
using FinanzasGrupo2API.Movimientos.Domain.Repositories;
using FinanzasGrupo2API.Movimientos.Domain.Services;
using FinanzasGrupo2API.Movimientos.Persistence.Repositories;
using FinanzasGrupo2API.Movimientos.Services;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Projects.Domain.Services;
using FinanzasGrupo2API.Projects.Persistence.Repositories;
using FinanzasGrupo2API.Projects.Services;
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
using FinanzasGrupo2API.TipoMovimientos.Persistence.Repositories;
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

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();

            services.AddScoped<IBonoRepository, BonoRepository>();
            services.AddScoped<IBonoService, BonoService>();

            services.AddScoped<IDataFrancesRepository, DataFrancesRepository>();
            services.AddScoped<IDataFrancesService, DataFrancesService>();

            services.AddScoped<ICrudRepository, CrudRepository>();
            services.AddScoped<ICrudService, CrudService>();

            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IMovimientoService, MovimientoService>();

            services.AddScoped<ITipoMovimientoRepository, TipoMovimientoRepository>();
            services.AddScoped<ITipoMovimientoService, TipoMovimientoService>();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.Services.SQL_Services;
using SkillManagement.DataAccess.sqlunitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;

namespace SkillAppAdoDapperWebApi
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AeroDbContext>(options => options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SkillAeroDB; Trusted_Connection = True;"));

            services.AddControllers();
            #region SQL repositories
            services.AddTransient<ISQLAeroplaneRepository, SQLAeroplaneRepository>();
            services.AddTransient<ISQLAeroportRepository, SQLAeroportRepository>();
            services.AddTransient<ISQLFlightRepository, SQLFlightRepository>();
            services.AddTransient<ISQLPassengerRepository, SQLPassengerRepository>();
            #endregion

            #region SQL services
            services.AddTransient<ISQLAeroplaneService, SQLAeroplaneService>();
            services.AddTransient<ISQLAeroportService, SQLAeroportService>();
            services.AddTransient<ISQLFlightService, SQLFlightService>();
            services.AddTransient<ISQLPassengerService, SQLPassengerService>();
            #endregion

            services.AddTransient<ISQLunitOfWork, SQLsqlunitOfWork>();

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IConfiguration>(_Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    },
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "weatherforecast";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

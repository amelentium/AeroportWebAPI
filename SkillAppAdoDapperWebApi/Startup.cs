using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;
using SkillManagement.DataAccess.sqlunitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SkillAppAdoDapperWebApi.BLL.Services;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Token;

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
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<AeroDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AeroTokenOptions.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AeroTokenOptions.AUDIENCE,
                        ValidateLifetime = true,

                        IssuerSigningKey = AeroTokenOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddControllers();
            #region SQL repositories
            services.AddTransient<IAeroplaneRepository, AeroplaneRepository>();
            services.AddTransient<IAeroportRepository, AeroportRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IPassengerRepository, PassengerRepository>();
            #endregion

            #region SQL services
            services.AddTransient<IAeroplaneService, AeroplaneService>();
            services.AddTransient<IAeroportService, AeroportService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IPassengerService, PassengerService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

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

            app.UseAuthentication();
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

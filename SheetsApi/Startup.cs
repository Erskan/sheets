using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SheetsApi.Middleware;
using SheetsApi.Settings;
using SheetsApi.Shared;
using SheetsApi.Shared.Interfaces;
using SheetsApi.Sheets;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SheetsApi.Forces;
using Swashbuckle.AspNetCore.Swagger;

namespace SheetsApi
{
    public class Startup
    {
        public IMapper Mapper { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Sheets API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT auth with bearer tokens.",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer", new string[] { }
                    },
                });
            });
            services.AddDbContext<SheetsDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddTransient<ISheetService, SheetService>();
            services.AddTransient<IForceService, ForceService>();
            services.AddScoped<ISheetsDbContext>(provider => provider.GetService<SheetsDbContext>());
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SheetsMappingProfile>();
            });
            services.AddSingleton<IMapper>(c => mappingConfig.CreateMapper());
            var jwtOptions = Configuration.GetSection("JwtOptions");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions["SigningKey"]));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtOptions["Issuer"];
                options.Audience = jwtOptions["Audience"];
                options.SigningCredentials = new SigningCredentials(
                    signingKey,
                    SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = jwtOptions["Issuer"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtOptions["Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.SaveToken = true;
            });

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sheets API v1");
            });

            app.UseMiddleware(typeof(ExceptionHandler));
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

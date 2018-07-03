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
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SheetsApi.Forces;
using SheetsApi.Games;
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
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("SheetsPolicy", builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));
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
            services.AddTransient<IGameService, GameService>();
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

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
                .AddEntityFrameworkStores<SheetsDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
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
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SheetsDbContext db, UserManager<IdentityUser<int>> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Run migration and seed if needed.
            db.Database.Migrate();
            InitializeDatabase.InitAsync(db, userManager);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sheets API v1");
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseMiddleware(typeof(ExceptionHandler));
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

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
            });
            services.AddDbContext<SheetsDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddTransient<ISheetService, SheetService>();
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SheetsMappingProfile>();
            });
            services.AddSingleton<IMapper>(c => mappingConfig.CreateMapper());

            services.AddMvc();
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

            app.UseMvc();
        }
    }
}

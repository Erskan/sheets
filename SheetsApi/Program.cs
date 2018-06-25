using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;
using Microsoft.Extensions.DependencyInjection;
using SheetsApi.Settings;
using SheetsApi.Shared;

namespace SheetsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.RollingFile("log-{Date}.txt")
                .CreateLogger();
            try
            {
                Log.Information("Starting Sheets API application...");
                var host = BuildWebHost(args);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<SheetsDbContext>();
                    InitializeDatabase.Init(context);
                    context.SaveChanges();
                }
                host.Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "The Sheets API application terminated unexpectedly.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
    }
}

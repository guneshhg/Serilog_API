using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            Log.Information("Starting Application");
            try
            {
                CreateHostBuilder(args).Build().MigrateDatabase().SeedDatabase().Run();

            }
            finally
            {
                Log.Information("Closing Application");
                Log.CloseAndFlush();
            }
        }


        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.AspNetCore",Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithMemoryUsage()
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithMachineName()
                .Enrich.WithCorrelationId()
                .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {SourceContext}  Memory:{MemoryUsage} Client Ip:{ClientIp} ClientAgent:{ClientAgent} Process Id:{ProcessId}  Process Name:{ProcessName} MachineName:{MachineName} Thread Id:{ThreadId} CorrelationId: {CorrelationId} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("C:\\Users\\gunes\\Logs\\logs.txt", rollingInterval:RollingInterval.Day, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {SourceContext}  Memory:{MemoryUsage} Client Ip:{ClientIp} ClientAgent:{ClientAgent} Process Id:{ProcessId}  Process Name:{ProcessName} MachineName:{MachineName} Thread Id:{ThreadId} CorrelationId: {CorrelationId} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class IHostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            context.Database.Migrate();

            return host;
        }
        public static IHost SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            SeedData.Initialize(context);
            return host;
        }
    }

}

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AspCoreEntityPostgres.Repository;
using AspCoreEntityPostgres.DBcontext;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspCoreEntityPostgres
{
#pragma warning disable CA1052 // “ипы статических заполнителей должны быть Static или NotInheritable
    public class Program
#pragma warning restore CA1052 // “ипы статических заполнителей должны быть Static или NotInheritable
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //     .UseStartup("Startup")
            //     .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
            //    .UseEnvironment("Development")
            //    .UseSetting("AspCoreEntityPostgres", "AspCoreEntityPostgres")
            //    .UseKestrel()
            //        .Configure(app =>
            //        {
            //            app.Run(async (context) => await context.Response.WriteAsync("Hi!").ConfigureAwait(false));
            //        })
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();
            //{
            //}
            //host.Run();

            using var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    using var context = services.GetRequiredService<ApplicationContext>();
                    UsersSampleData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

            public static IWebHost BuildWebHost(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .UseIISIntegration()
           .Build();
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<KestrelServerOptions>(
                    context.Configuration.GetSection("Kestrel"));
                })
                    .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
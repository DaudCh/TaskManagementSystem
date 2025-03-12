using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;



namespace TaskI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Task application..."); //Testing for PR
            // Create a Host to manage services
            var host = CreateHostBuilder(args).Build();

            // Run database migrations
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    Console.WriteLine("Applying migrations...");
                    context.Database.Migrate();
                    Console.WriteLine("Migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                }
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Load configuration
                    var configuration = context.Configuration;

                    // Register repository layer (removes direct dependency on DbContext)
                    services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Data Source=DESKTOP-4F8B9BO\\MSSQLSERVER01;Initial Catalog=TaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
                });


                }
  }

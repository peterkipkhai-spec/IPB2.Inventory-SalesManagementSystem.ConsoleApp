using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Forms;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm
{
    internal static class Program
    {
        // Application-wide Host instance
        public static IHost AppHost { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Database
                    services.AddDbContext<InventorySalesDbContext>();

                    // Services
                    services.AddScoped<SupplierService>();
                    services.AddScoped<CategoryService>();
                    services.AddScoped<ProductService>();
                    services.AddScoped<StaffService>();
                    services.AddScoped<StockService>();
                    services.AddScoped<SalesService>();

                    // Forms
                    services.AddTransient<MainForm>();
                    services.AddTransient<SupplierForm>();
                    services.AddTransient<CategoryForm>();
                    services.AddTransient<ProductForm>();
                    services.AddTransient<StaffForm>();
                    services.AddTransient<StockForm>();
                    services.AddTransient<SalesForm>();
                    services.AddTransient<ReportForm>();
                })
                .Build();

            AppHost = host;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var mainForm = services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}
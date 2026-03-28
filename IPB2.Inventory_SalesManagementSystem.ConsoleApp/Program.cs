using IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
{
    services.AddDbContext<InventorySalesDbContext>();
    services.AddScoped<ISupplierService, SupplierService>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IStockService, StockService>();
    services.AddScoped<ISalesService, SalesService>();
    services.AddScoped<IReportService, ReportService>();
})
.Build();

using var scope = host.Services.CreateScope();
var supplierService = scope.ServiceProvider.GetRequiredService<ISupplierService>();
var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
var stockService = scope.ServiceProvider.GetRequiredService<IStockService>();
var salesService = scope.ServiceProvider.GetRequiredService<ISalesService>();
var reportService = scope.ServiceProvider.GetRequiredService<IReportService>();

bool exit = false;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine(" INVENTORY & SALES SYSTEM");
    Console.WriteLine("======================================");
    Console.WriteLine("1. Supplier Management");
    Console.WriteLine("2. Product Management");
    Console.WriteLine("3. Stock Management");
    Console.WriteLine("4. Sales");
    Console.WriteLine("5. Reports");
    Console.WriteLine("6. Exit");
    Console.Write("Enter your choice: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1": await SupplierMenu(supplierService); break;
        case "2": await ProductMenu(productService); break;
        case "3": await StockMenu(stockService); break;
        case "4": await SalesMenu(salesService); break;
        case "5": await ReportMenu(reportService); break;
        case "6": exit = true; break;
        default:
            Console.WriteLine("Invalid choice!");
            Console.ReadKey();
            break;
    }
}

#region Supplier Menu
async Task SupplierMenu(ISupplierService service)
{
    Console.Clear();

    var list = await service.GetSuppliersAsync();

    foreach (var s in list)
        Console.WriteLine($"{s.SupplierID} - {s.CompanyName}");

    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
#endregion

#region Product Menu
async Task ProductMenu(IProductService service)
{
    Console.Clear();

    var list = await service.GetProductsAsync();

    foreach (var p in list)
        Console.WriteLine($"{p.ProductID} - {p.ProductName} | Stock: {p.QuantityInStock}");

    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
#endregion

#region Stock Menu
async Task StockMenu(IStockService service)
{
    Console.Clear();

    Console.Write("Product ID: ");
    int productId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantity: ");
    int qty = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Type (IN/OUT): ");
    var type = Console.ReadLine() ?? "";

    var result = await service.UpdateStockAsync(productId, qty, type);

    if (!result.success)
    {
        Console.WriteLine(result.message);
    }
    else
    {
        Console.WriteLine(result.message);
    }

    Console.ReadKey();
}
#endregion

#region Sales Menu
async Task SalesMenu(ISalesService service)
{
    Console.Clear();

    Console.Write("Staff ID: ");
    int staffId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Product ID: ");
    int productId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantity: ");
    int qty = int.Parse(Console.ReadLine() ?? "0");

    var result = await service.ProcessSaleAsync(staffId, productId, qty);

    if (!result.success)
    {
        Console.WriteLine(result.message);
    }
    else
    {
        Console.WriteLine(result.message);
    }

    Console.ReadKey();
}
#endregion

#region Report Menu
async Task ReportMenu(IReportService service)
{
    Console.Clear();

    Console.WriteLine("=== LOW STOCK PRODUCTS (<10) ===");

    var list = await service.GetLowStockProductsAsync(10);

    foreach (var p in list)
    {
        Console.WriteLine($"{p.ProductID} - {p.ProductName} | Stock: {p.QuantityInStock}");
    }

    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
#endregion
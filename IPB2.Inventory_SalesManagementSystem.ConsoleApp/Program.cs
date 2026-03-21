using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
{
    services.AddDbContext<InventorySalesDbContext>();
})
.Build();

using var scope = host.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<InventorySalesDbContext>();

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
        case "1": await SupplierMenu(db); break;
        case "2": await ProductMenu(db); break;
        case "3": await StockMenu(db); break;
        case "4": await SalesMenu(db); break;
        case "5": await ReportMenu(db); break;
        case "6": exit = true; break;
        default:
            Console.WriteLine("Invalid choice!");
            Console.ReadKey();
            break;
    }
}

#region Supplier Menu
async Task SupplierMenu(InventorySalesDbContext db)
{
    Console.Clear();

    var list = await db.Suppliers.ToListAsync();

    foreach (var s in list)
        Console.WriteLine($"{s.SupplierID} - {s.CompanyName}");

    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
#endregion

#region Product Menu
async Task ProductMenu(InventorySalesDbContext db)
{
    Console.Clear();

    var list = await db.Products.ToListAsync();

    foreach (var p in list)
        Console.WriteLine($"{p.ProductID} - {p.ProductName} | Stock: {p.QuantityInStock}");

    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
#endregion

#region Stock Menu
async Task StockMenu(InventorySalesDbContext db)
{
    Console.Clear();

    Console.Write("Product ID: ");
    int productId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantity: ");
    int qty = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Type (IN/OUT): ");
    var type = Console.ReadLine();

    var product = await db.Products
        .FirstOrDefaultAsync(x => x.ProductID == productId);

    if (product == null)
    {
        Console.WriteLine("Product not found");
        Console.ReadKey();
        return;
    }

    if (type == "IN")
    {
        product.QuantityInStock += qty;
    }
    else if (type == "OUT")
    {
        if (product.QuantityInStock < qty)
        {
            Console.WriteLine("Not enough stock!");
            Console.ReadKey();
            return;
        }

        product.QuantityInStock -= qty;
    }
    else
    {
        Console.WriteLine("Invalid type!");
        Console.ReadKey();
        return;
    }

    db.StockTransactions.Add(new StockTransaction
    {
        ProductID = productId,
        Quantity = qty,
        TransactionType = type
    });

    await db.SaveChangesAsync();

    Console.WriteLine("Stock updated!");
    Console.ReadKey();
}
#endregion

#region Sales Menu
async Task SalesMenu(InventorySalesDbContext db)
{
    Console.Clear();

    Console.Write("Staff ID: ");
    int staffId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Product ID: ");
    int productId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantity: ");
    int qty = int.Parse(Console.ReadLine() ?? "0");

    var product = await db.Products
        .FirstOrDefaultAsync(x => x.ProductID == productId);

    if (product == null || product.QuantityInStock < qty)
    {
        Console.WriteLine("Invalid product or insufficient stock");
        Console.ReadKey();
        return;
    }

    decimal subtotal = (decimal)(qty * product.Price);

    var sale = new Sale
    {
        StaffID = staffId,
        TotalAmount = subtotal,
        SaleDate = DateTime.Now
    };

    db.Sales.Add(sale);
    await db.SaveChangesAsync();

    db.SaleItems.Add(new SaleItem { SaleID = (int)sale.SaleID, ProductID = productId, Quantity = qty, Price = (decimal)product.Price, SubTotal = subtotal });

    product.QuantityInStock -= qty;

    await db.SaveChangesAsync();

    Console.WriteLine("Sale completed!");
    Console.ReadKey();
}
#endregion

#region Report Menu
async Task ReportMenu(InventorySalesDbContext db)
{
    Console.Clear();

    Console.WriteLine("=== LOW STOCK PRODUCTS (<10) ===");

    var list = await db.Products
        .Where(x => x.QuantityInStock < 10)
        .ToListAsync();

    foreach (var p in list)
    {
        Console.WriteLine($"{p.ProductID} - {p.ProductName} | Stock: {p.QuantityInStock}");
    }

    Console.WriteLine("Press any key...");
    Console.ReadKey();

}
#endregion
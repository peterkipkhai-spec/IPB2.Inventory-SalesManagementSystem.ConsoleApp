using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =========================
// Services & DbContext
// =========================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventorySalesDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Example service injection
builder.Services.AddScoped<ITestService, InventoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Suppliers API
app.MapGet("/api/Suppliers", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Suppliers.AsNoTracking().OrderBy(x => x.SupplierID);
    var totalCount = await query.CountAsync();
    var data = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
        Data = data
    });
});

app.MapPost("/api/Suppliers", async (InventorySalesDbContext db, Supplier model) =>
{
    db.Suppliers.Add(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapPut("/api/Suppliers", async (InventorySalesDbContext db, Supplier model) =>
{
    db.Suppliers.Update(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapDelete("/api/Suppliers/{id}", async (InventorySalesDbContext db, int id) =>
{
    var data = await db.Suppliers.FindAsync(id);
    if (data == null) return Results.NotFound();
    db.Suppliers.Remove(data);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region Categories API
app.MapGet("/api/Categories", async (InventorySalesDbContext db) =>
{
    return Results.Ok(await db.Categories.AsNoTracking().ToListAsync());
});

app.MapPost("/api/Categories", async (InventorySalesDbContext db, Category model) =>
{
    db.Categories.Add(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapPut("/api/Categories", async (InventorySalesDbContext db, Category model) =>
{
    db.Categories.Update(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapDelete("/api/Categories/{id}", async (InventorySalesDbContext db, int id) =>
{
    var data = await db.Categories.FindAsync(id);
    if (data == null) return Results.NotFound();
    db.Categories.Remove(data);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region Staffs API
app.MapGet("/api/Staffs", async (InventorySalesDbContext db) =>
{
    return Results.Ok(await db.Staffs.AsNoTracking().ToListAsync());
});

app.MapPost("/api/Staffs", async (InventorySalesDbContext db, Staff model) =>
{
    db.Staffs.Add(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapPut("/api/Staffs", async (InventorySalesDbContext db, Staff model) =>
{
    db.Staffs.Update(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapDelete("/api/Staffs/{id}", async (InventorySalesDbContext db, int id) =>
{
    var data = await db.Staffs.FindAsync(id);
    if (data == null) return Results.NotFound();
    db.Staffs.Remove(data);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region Products API
app.MapGet("/api/Products", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Products.Include(x => x.Category).Include(x => x.Supplier).AsNoTracking().OrderBy(x => x.ProductID);
    var totalCount = await query.CountAsync();
    var data = await query.Skip((pageNo - 1) * pageSize).Take(pageSize)
        .Select(x => new
        {
            x.ProductID,
            x.ProductName,
            Category = x.Category.CategoryName,
            Supplier = x.Supplier.CompanyName,
            x.Price,
            x.QuantityInStock
        })
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
        Data = data
    });
});

app.MapPost("/api/Products", async (InventorySalesDbContext db, Product model) =>
{
    db.Products.Add(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapPut("/api/Products", async (InventorySalesDbContext db, Product model) =>
{
    db.Products.Update(model);
    await db.SaveChangesAsync();
    return Results.Ok(model);
});

app.MapDelete("/api/Products/{id}", async (InventorySalesDbContext db, int id) =>
{
    var data = await db.Products.FindAsync(id);
    if (data == null) return Results.NotFound();
    db.Products.Remove(data);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// Product Search API
app.MapGet("/api/Products/Search", async (InventorySalesDbContext db,
    string? keyword = null,
    string? category = null,
    string? supplier = null,
    int pageNo = 1,
    int pageSize = 10) =>
{
    var query = db.Products.Include(x => x.Category).Include(x => x.Supplier).AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(keyword))
    {
        keyword = keyword.Trim();
        query = query.Where(x => x.ProductName.Contains(keyword));
    }

    if (!string.IsNullOrWhiteSpace(category))
    {
        category = category.Trim();
        query = query.Where(x => x.Category != null && x.Category.CategoryName == category);
    }

    if (!string.IsNullOrWhiteSpace(supplier))
    {
        supplier = supplier.Trim();
        query = query.Where(x => x.Supplier != null && x.Supplier.CompanyName == supplier);
    }

    query = query.OrderBy(x => x.ProductID);
    var totalCount = await query.CountAsync();
    var data = await query.Skip((pageNo - 1) * pageSize).Take(pageSize)
        .Select(x => new
        {
            x.ProductID,
            x.ProductName,
            Category = x.Category.CategoryName,
            Supplier = x.Supplier.CompanyName,
            x.Price,
            x.QuantityInStock
        })
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
        Data = data
    });
});
#endregion

#region Stock API
app.MapPost("/api/Stock/StockIn", async (InventorySalesDbContext db, int productId, int qty) =>
{
    var product = await db.Products.FindAsync(productId);
    if (product == null) return Results.NotFound("Product not found");
    product.QuantityInStock += qty;
    db.StockTransactions.Add(new StockTransaction { ProductID = productId, Quantity = qty, TransactionType = "IN" });
    await db.SaveChangesAsync();
    return Results.Ok(product);
});

app.MapPost("/api/Stock/StockOut", async (InventorySalesDbContext db, int productId, int qty) =>
{
    var product = await db.Products.FindAsync(productId);
    if (product == null) return Results.NotFound();
    if (product.QuantityInStock < qty) return Results.BadRequest("Not enough stock");

    product.QuantityInStock -= qty;
    db.StockTransactions.Add(new StockTransaction { ProductID = productId, Quantity = qty, TransactionType = "OUT" });
    await db.SaveChangesAsync();
    return Results.Ok(product);
});
#endregion

#region Sales API
app.MapPost("/api/Sales/Create", async (InventorySalesDbContext db, int staffId, List<SaleItem> items) =>
{
    decimal total = 0;
    foreach (var item in items)
    {
        var product = await db.Products.FindAsync(item.ProductID);
        if (product == null || product.QuantityInStock < item.Quantity)
            return Results.BadRequest("Invalid product or insufficient stock");

        item.Price = (decimal)product.Price;
        item.SubTotal = item.Quantity * item.Price;
        total += (decimal)item.SubTotal;
        product.QuantityInStock -= item.Quantity;
    }

    var sale = new Sale { StaffID = staffId, TotalAmount = total, SaleDate = DateTime.Now };
    db.Sales.Add(sale);
    await db.SaveChangesAsync();

    foreach (var item in items)
    {
        item.SaleID = (int)sale.SaleID;
        db.SaleItems.Add(item);
    }

    await db.SaveChangesAsync();
    return Results.Ok(sale);
});
#endregion

#region Reports API
app.MapGet("/api/Reports/LowStock", async (InventorySalesDbContext db) =>
{
    var data = await db.Products.Where(x => x.QuantityInStock < 10).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/api/Reports/ProductSummary", async (InventorySalesDbContext db) =>
{
    var data = await db.SaleItems
        .GroupBy(x => x.ProductID)
        .Select(g => new
        {
            ProductID = g.Key,
            TotalQty = g.Sum(x => x.Quantity),
            TotalSales = g.Sum(x => x.SubTotal)
        })
        .ToListAsync();

    return Results.Ok(data);
});
#endregion

app.Run();


// =========================
// Example Service
// =========================
public interface ITestService { void Test(); }

public class InventoryService : ITestService { public void Test() { } }
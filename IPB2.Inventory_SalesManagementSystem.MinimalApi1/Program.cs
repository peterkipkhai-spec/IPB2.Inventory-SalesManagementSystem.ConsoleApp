using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services;
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

builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IReportService, ReportService>();

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
app.MapGet("/api/Suppliers", async (ISupplierService service, int pageNo = 1, int pageSize = 10) =>
{
    return Results.Ok(await service.GetSuppliersAsync(pageNo, pageSize));
});

app.MapPost("/api/Suppliers", async (ISupplierService service, Supplier model) =>
{
    return Results.Ok(await service.CreateSupplierAsync(model));
});

app.MapPut("/api/Suppliers", async (ISupplierService service, Supplier model) =>
{
    return Results.Ok(await service.UpdateSupplierAsync(model));
});

app.MapDelete("/api/Suppliers/{id}", async (ISupplierService service, int id) =>
{
    var success = await service.DeleteSupplierAsync(id);
    return success ? Results.Ok() : Results.NotFound();
});
#endregion

#region Categories API
app.MapGet("/api/Categories", async (ICategoryService service) =>
{
    return Results.Ok(await service.GetCategoriesAsync());
});

app.MapPost("/api/Categories", async (ICategoryService service, Category model) =>
{
    return Results.Ok(await service.CreateCategoryAsync(model));
});

app.MapPut("/api/Categories", async (ICategoryService service, Category model) =>
{
    return Results.Ok(await service.UpdateCategoryAsync(model));
});

app.MapDelete("/api/Categories/{id}", async (ICategoryService service, int id) =>
{
    var success = await service.DeleteCategoryAsync(id);
    return success ? Results.Ok() : Results.NotFound();
});
#endregion

#region Staffs API
app.MapGet("/api/Staffs", async (IStaffService service) =>
{
    return Results.Ok(await service.GetStaffsAsync());
});

app.MapPost("/api/Staffs", async (IStaffService service, Staff model) =>
{
    return Results.Ok(await service.CreateStaffAsync(model));
});

app.MapPut("/api/Staffs", async (IStaffService service, Staff model) =>
{
    return Results.Ok(await service.UpdateStaffAsync(model));
});

app.MapDelete("/api/Staffs/{id}", async (IStaffService service, int id) =>
{
    var success = await service.DeleteStaffAsync(id);
    return success ? Results.Ok() : Results.NotFound();
});
#endregion

#region Products API
app.MapGet("/api/Products", async (IProductService service, int pageNo = 1, int pageSize = 10) =>
{
    return Results.Ok(await service.GetProductsAsync(pageNo, pageSize));
});

app.MapPost("/api/Products", async (IProductService service, Product model) =>
{
    return Results.Ok(await service.CreateProductAsync(model));
});

app.MapPut("/api/Products", async (IProductService service, Product model) =>
{
    return Results.Ok(await service.UpdateProductAsync(model));
});

app.MapDelete("/api/Products/{id}", async (IProductService service, int id) =>
{
    var success = await service.DeleteProductAsync(id);
    return success ? Results.Ok() : Results.NotFound();
});

// Product Search API
app.MapGet("/api/Products/Search", async (IProductService service,
    string? keyword = null,
    string? category = null,
    string? supplier = null,
    int pageNo = 1,
    int pageSize = 10) =>
{
    return Results.Ok(await service.SearchProductsAsync(keyword, category, supplier, pageNo, pageSize));
});
#endregion

#region Stock API
app.MapPost("/api/Stock/StockIn", async (IStockService service, int productId, int qty) =>
{
    var result = await service.StockInAsync(productId, qty);
    return result.success ? Results.Ok(result.product) : Results.BadRequest(result.message);
});

app.MapPost("/api/Stock/StockOut", async (IStockService service, int productId, int qty) =>
{
    var result = await service.StockOutAsync(productId, qty);
    return result.success ? Results.Ok(result.product) : Results.BadRequest(result.message);
});
#endregion

#region Sales API
app.MapPost("/api/Sales/Create", async (ISalesService service, int staffId, List<SaleItem> items) =>
{
    var result = await service.CreateSaleAsync(staffId, items);
    return result.success ? Results.Ok(result.sale) : Results.BadRequest(result.message);
});
#endregion

#region Reports API
app.MapGet("/api/Reports/LowStock", async (IReportService service) =>
{
    return Results.Ok(await service.GetLowStockAsync());
});

app.MapGet("/api/Reports/ProductSummary", async (IReportService service) =>
{
    return Results.Ok(await service.GetProductSummaryAsync());
});
#endregion

app.Run();


// =========================
// Example Service
// =========================
public interface ITestService { void Test(); }

public class InventoryService : ITestService { public void Test() { } }
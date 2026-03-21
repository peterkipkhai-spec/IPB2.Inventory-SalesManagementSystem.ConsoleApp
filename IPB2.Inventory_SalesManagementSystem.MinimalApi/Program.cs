using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext - Fixed registration
builder.Services.AddDbContext<InventorySalesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Example Service
builder.Services.AddScoped<ITestService, GTService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// =======================================
// 📦 PRODUCTS
// =======================================

// GET
app.MapGet("/api/Products", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var lst = await db.Products
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(lst);
})
.WithName("GetProducts")
.WithOpenApi();

// LIST
app.MapGet("/api/Products/List", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    if (pageNo <= 0) pageNo = 1;
    if (pageSize <= 0) pageSize = 10;

    var query = db.Products
        .AsNoTracking()
        .OrderBy(x => x.ProductID);

    var totalCount = await query.CountAsync();

    var data = await query
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .Select(x => new
        {
            x.ProductID,
            x.ProductName,
            x.UnitPrice,
            x.QuantityInStock
        })
        .ToListAsync();

    var response = new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
        Data = data
    };

    return Results.Ok(response);
})
.WithName("GetProductsList")
.WithOpenApi();

// SEARCH
app.MapGet("/api/Products/Search", async (
    InventorySalesDbContext db,
    string? keyword = null,
    int pageNo = 1,
    int pageSize = 10) =>
{
    var query = db.Products.AsQueryable();

    if (!string.IsNullOrWhiteSpace(keyword))
    {
        keyword = keyword.Trim();
        query = query.Where(x => x.ProductName.Contains(keyword));
    }

    var totalCount = await query.CountAsync();

    var data = await query
        .OrderBy(x => x.ProductID)
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var response = new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
        Data = data
    };

    return Results.Ok(response);
})
.WithName("SearchProducts")
.WithOpenApi();

// =======================================
// 📦 SUPPLIERS
// =======================================

app.MapGet("/api/Suppliers/List", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Suppliers
        .AsNoTracking()
        .OrderBy(x => x.SupplierID);

    var totalCount = await query.CountAsync();

    var data = await query
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        Data = data
    });
})
.WithName("GetSuppliersList")
.WithOpenApi();

// =======================================
// 📦 CATEGORIES
// =======================================

app.MapGet("/api/Categories/List", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Categories
        .AsNoTracking()
        .OrderBy(x => x.CategoryID);

    var totalCount = await query.CountAsync();

    var data = await query
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        Data = data
    });
})
.WithName("GetCategoriesList")
.WithOpenApi();

// =======================================
// 📦 SALES
// =======================================

app.MapGet("/api/Sales/List", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Sales
        .AsNoTracking()
        .OrderByDescending(x => x.SaleID);

    var totalCount = await query.CountAsync();

    var data = await query
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        Data = data
    });
})
.WithName("GetSalesList")
.WithOpenApi();

// =======================================
// 📊 REPORT - LOW STOCK
// =======================================

app.MapGet("/api/Reports/LowStock", async (InventorySalesDbContext db, int pageNo = 1, int pageSize = 10) =>
{
    var query = db.Products
        .Where(x => x.QuantityInStock <= x.MinimumStock)
        .AsNoTracking();

    var totalCount = await query.CountAsync();

    var data = await query
        .OrderBy(x => x.QuantityInStock)
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        PageNo = pageNo,
        PageSize = pageSize,
        TotalCount = totalCount,
        Data = data
    });
})
.WithName("LowStockReport")
.WithOpenApi();

app.Run();

// =======================================
// 🔧 SERVICES (SAME STYLE AS YOUR CODE)
// =======================================

public interface ITestService
{
    void Test();
}

public class PLMService : ITestService
{
    public void Test()
    {
    }
}

public class GTService : ITestService
{
    public void Test()
    {
    }
}

public class AccountController
{
    private readonly ITestService _testService;

    public AccountController(ITestService testService)
    {
        _testService = testService;
    }

    public void Test()
    {
        _testService.Test();
    }
}
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface IProductService
    {
        Task<object> GetProductsAsync(int pageNo, int pageSize);
        Task<object> SearchProductsAsync(string? keyword, string? category, string? supplier, int pageNo, int pageSize);
        Task<Product> CreateProductAsync(Product model);
        Task<Product> UpdateProductAsync(Product model);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly InventorySalesDbContext _db;

        public ProductService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<object> GetProductsAsync(int pageNo, int pageSize)
        {
            var query = _db.Products.Include(x => x.Category).Include(x => x.Supplier).AsNoTracking().OrderBy(x => x.ProductID);
            var totalCount = await query.CountAsync();
            var data = await query.Skip((pageNo - 1) * pageSize).Take(pageSize)
                .Select(x => new
                {
                    x.ProductID,
                    x.ProductName,
                    Category = x.Category!.CategoryName,
                    Supplier = x.Supplier!.CompanyName,
                    x.Price,
                    x.QuantityInStock
                })
                .ToListAsync();

            return new
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = totalCount,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                Data = data
            };
        }

        public async Task<object> SearchProductsAsync(string? keyword, string? category, string? supplier, int pageNo, int pageSize)
        {
            var query = _db.Products.Include(x => x.Category).Include(x => x.Supplier).AsNoTracking().AsQueryable();

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
                    Category = x.Category!.CategoryName,
                    Supplier = x.Supplier!.CompanyName,
                    x.Price,
                    x.QuantityInStock
                })
                .ToListAsync();

            return new
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = totalCount,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                Data = data
            };
        }

        public async Task<Product> CreateProductAsync(Product model)
        {
            _db.Products.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            _db.Products.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var data = await _db.Products.FindAsync(id);
            if (data == null) return false;
            
            _db.Products.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

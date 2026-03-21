using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Data
{
    public class AppDbContextFactory
    {
        public static InventorySalesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InventorySalesDbContext>()
                .UseSqlServer("Server=.;Database=InventorySalesDB;User Id=sa;Password=sasa@123;TrustServerCertificate=True;")
                .Options;

            return new InventorySalesDbContext(options);
        }
    }
}

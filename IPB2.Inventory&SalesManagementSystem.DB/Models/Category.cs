using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    public object CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public string Description { get; set; }
}

using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class StockTransaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }
    public int ProductID { get; set; }
    public int? Quantity { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Product? Product { get; set; }
}

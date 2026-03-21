using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class Sale
{
    public int SaleId { get; set; }
    public int? SaleID { get; set; }
    public DateTime? SaleDate { get; set; }

    public int? StaffId { get; set; }
    public int StaffID { get; set; }
    public decimal? TotalAmount { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual Staff? Staff { get; set; }
}

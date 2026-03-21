using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string? Position { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

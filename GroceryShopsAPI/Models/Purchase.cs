using System;
using System.Collections.Generic;

namespace GroceryShopsAPI.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientId { get; set; }
        public required Client Client { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
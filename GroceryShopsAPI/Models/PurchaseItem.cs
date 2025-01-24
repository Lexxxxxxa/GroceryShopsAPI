namespace GroceryShopsAPI.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public required Purchase Purchase { get; set; }

        public int ProductId { get; set; }
        public required Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
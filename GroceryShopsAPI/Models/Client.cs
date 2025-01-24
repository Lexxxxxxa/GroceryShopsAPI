using System;
using System.Collections.Generic;

namespace GroceryShopsAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryShopsAPI.Data;
using GroceryShopsAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly GroceryShopContext _context;

        public ClientsController(GroceryShopContext context)
        {
            _context = context;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdays([FromQuery] DateTime date)
        {
            var clients = await _context.Clients
                .Where(c => c.BirthDate.Date == date.Date)
                .Select(c => new { c.Id, c.FullName })
                .ToListAsync();

            return Ok(clients);
        }

        [HttpGet("recent-buyers")]
        public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
        {
            var cutoffDate = DateTime.Now.AddDays(-days);

            var clients = await _context.Purchases
                .Where(p => p.PurchaseDate >= cutoffDate)
                .GroupBy(p => p.Client)
                .Select(g => new
                {
                    ClientId = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.PurchaseDate)
                })
                .ToListAsync();

            return Ok(clients);
        }

        [HttpGet("popular-categories")]
        public async Task<IActionResult> GetPopularCategories([FromQuery] int clientId)
        {
            var purchases = await _context.Purchases
                .Include(p => p.PurchaseItems)
                .ThenInclude(pi => pi.Product)
                .Where(p => p.ClientId == clientId)
                .SelectMany(p => p.PurchaseItems)
                .GroupBy(pi => pi.Product.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Quantity = g.Sum(pi => pi.Quantity)
                })
                .ToListAsync();

            return Ok(purchases);
        }
    }
}
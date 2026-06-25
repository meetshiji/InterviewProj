using InterviewProj.Data;
using InterviewProj.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterviewProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
       {
        private readonly OnlineShopDbContext _context;
        List<Orders> lst = null;
        private readonly ILogger<OrderController> _logger;
        public OrderController(ILogger<OrderController> logger, OnlineShopDbContext context)
        {
            _logger = logger;
            _context = context;
            lst = new List<Orders>();
        }


        //[Authorize]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            try
            {
                return await _context.Orders.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving orders.");
                return StatusCode(500, "Internal server error");

            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Orders order)
        {
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrders),
                new { id = order.OrderId },
                order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Orders order)
        {
            if (id != order.OrderId)
                return BadRequest();

            _context.Entry(order).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

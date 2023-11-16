using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurantfavesBackend.Models;
using restaurantfavesBackend.Models.Data;

namespace restaurantfavesBackend.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet("/orders")]
        public IActionResult GetOrders()
        {
            return Ok(_appDbContext.Order.ToList());
        }
        [HttpGet("/orders/{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _appDbContext.Order.FirstOrDefault();
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost("/orders")]
        public IActionResult CreateOrder([FromBody]Order order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbContext.Order.Add(order);
            var orderId = _appDbContext.SaveChanges();
            order.Id = orderId;
            return Ok(order);
        }
        [HttpPut("/orders/{id}")]
        public IActionResult UpdateOrder([FromBody]Order order, int id) 
        {
            var dbOrder= _appDbContext.Order.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return NotFound();
            }
            dbOrder.Description= order.Description;
            dbOrder.Restaurant= order.Restaurant;
            dbOrder.Rating= order.Rating;
            dbOrder.OrderAgain= order.OrderAgain;
            _appDbContext.SaveChanges();
            return Ok(dbOrder);
        }
        [HttpDelete("/orders/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _appDbContext.Order.FirstOrDefault(x=>x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            _appDbContext.Order.Remove(order);
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}

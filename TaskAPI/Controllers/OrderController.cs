using Microsoft.AspNetCore.Mvc;
using TaskAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class OrderController : Controller
    {
        private NorthwndDbContext _dbContext;
        public OrderController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Order> temp = _dbContext.Orders.ToList();
            return Ok(temp);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Order temp = _dbContext.Orders.Include(x=>x.ShipVia).Include(x=>x.Customer).Include(x=>x.Employee).Where(x => x.OrderID == id).SingleOrDefault();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

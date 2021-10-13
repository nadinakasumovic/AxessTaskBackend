using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Data;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class OrderDetailsController : Controller
    {
        NorthwndDbContext _dbContext;
        public OrderDetailsController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            List<OrderDetails> temp = _dbContext.OrderDetails.Include(x => x.Product).Include(x => x.Product.Supplier).Include(x => x.Product.Category).Where(x => x.OrderID == id).Select(x=>new OrderDetails() { 
                OrderID=x.OrderID,
                ProductID=x.ProductID,
                Discount=x.Discount,
                Order=x.Order,
                Product=x.Product,
                Quantity=x.Quantity,
                UnitPrice=x.UnitPrice,
            }).ToList();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

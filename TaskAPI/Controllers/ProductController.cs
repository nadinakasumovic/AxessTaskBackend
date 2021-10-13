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
    [Route("API/[Controller]")]
    public class ProductController : Controller
    {
        private NorthwndDbContext _dbContext;
        public ProductController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Product> temp = _dbContext.Products.ToList();
            return Ok(temp);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Product temp = _dbContext.Products.Include(x=>x.Supplier).Include(x => x.Category).Where(x => x.ProductID == id).SingleOrDefault();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

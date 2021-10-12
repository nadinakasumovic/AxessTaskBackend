using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Data;
using TaskAPI.Model;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CategoryController : Controller
    {
        private NorthwndDbContext _dbContext;
        public CategoryController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Category> temp = _dbContext.Categories.ToList();
            return Ok(temp);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Category temp = _dbContext.Categories.Where(x => x.CategoryID == id).SingleOrDefault();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Data;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class SupplierController : Controller
    {
        private NorthwndDbContext _dbContext;
        public SupplierController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Supplier> temp = _dbContext.Suppliers.ToList();
            return Ok(temp);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Supplier temp = _dbContext.Suppliers.Where(x => x.SupplierID == id).SingleOrDefault();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

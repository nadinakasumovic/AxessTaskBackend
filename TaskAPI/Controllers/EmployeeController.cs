using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Data;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class EmployeeController : Controller
    {
        NorthwndDbContext _dbContext;
        public EmployeeController(NorthwndDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Employee temp = _dbContext.Employees.Where(x => x.EmployeeID == id).SingleOrDefault();
            if (temp != null)
            {
                return Ok(temp);
            }
            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        EventContext db;
        public InfoController(EventContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Field>>> GetFields(int id)
        {
            var field = await db.Fields.Where(x => x.EventId == id).ToListAsync();
            if (field == null)
                return NotFound();
            return new ObjectResult(field);
        }
    }
}

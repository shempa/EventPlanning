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
    public class FieldsController : ControllerBase
    {
        EventContext db;
        public FieldsController(EventContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Field>> Get(int id)
        {
            Field field = await db.Fields.FirstOrDefaultAsync(x => x.Id == id);
            if (field == null)
                return NotFound();
            return new ObjectResult(field);
        }        

        [HttpPost]
        public async Task<ActionResult<Field>> Post(Field field)
        {
            if (field == null)
                return BadRequest();

            if (field.Name == "" || field.Value == "")
                return BadRequest();

            db.Fields.Add(field);
            await db.SaveChangesAsync();
            return Ok(field);
        }

        [HttpPut]
        public async Task<ActionResult<Field>> Put(Field field)
        {
            if (field == null)
                return BadRequest();

            if (!db.Fields.Any(x => x.Id == field.Id))
                return NotFound();

            db.Update(field);
            await db.SaveChangesAsync();
            return Ok(field);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Field>> Delete(int id)
        {
            Field field = db.Fields.FirstOrDefault(x => x.Id == id);
            if (field == null)
            {
                return NotFound();
            }
            db.Fields.Remove(field);
            await db.SaveChangesAsync();
            return Ok(field);
        }
    }
}

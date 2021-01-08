using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        EventContext db;
        public EventsController(EventContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            var events = await db.Events.ToListAsync();
            return events;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            Event events = await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (events == null)
                return NotFound();
            return new ObjectResult(events);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(Event events)
        {
            if (events == null)
                return BadRequest();

            if (events.Name == "" || events.Date == null)
                return BadRequest();

            db.Events.Add(events);
            await db.SaveChangesAsync();
            return Ok(events);
        }
        
        [HttpPut]
        public async Task<ActionResult<Event>> Put(Event events)
        {
            if (events == null)
            {
                return BadRequest();
            }
            if (!db.Events.Any(x => x.Id == events.Id))
            {
                return NotFound();
            }

            db.Update(events);
            await db.SaveChangesAsync();
            return Ok(events);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            Event events = db.Events.FirstOrDefault(x => x.Id == id);
            if (events == null)
            {
                return NotFound();
            }
            db.Events.Remove(events);
            await db.SaveChangesAsync();
            return Ok(events);
        }

    }
}

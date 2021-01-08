using EventPlanning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> manager)
        {
            _userManager = manager;
        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await _userManager.UpdateAsync(user);
            /*
            db.Update(user);
            await db.SaveChangesAsync();
            */
            return Ok(user);
        }
    }
}

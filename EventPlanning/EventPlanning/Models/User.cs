using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EventPlanning.Models
{
    public class User : IdentityUser
    {
        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}

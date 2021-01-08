using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EventPlanning.Models
{
    public class EventContext : DbContext //DbContext IdentityDbContext<User> 
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Field> Fields { get; set; }
        //public override DbSet<User> Users { get; set; }
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
          //  Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }
    }
}

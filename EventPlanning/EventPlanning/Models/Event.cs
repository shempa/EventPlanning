using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanning.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();
        public List<User> Users { get; set; } = new List<User>();
    }
}

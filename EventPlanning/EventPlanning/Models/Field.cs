using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanning.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value {get; set;}
        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}

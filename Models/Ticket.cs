using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextCard.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
        public string SprintId { get; set; }
        public Sprint Sprint { get; set; }

    }
}

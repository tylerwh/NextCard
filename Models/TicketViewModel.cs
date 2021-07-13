﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextCard.Models
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            CurrentTicket = new Ticket();
        }
        public Filters Filters { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Ticket CurrentTicket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextCard.Models;

namespace NextCard.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            var model = new TicketViewModel
            {
                Filters = filters,
                Sprints = context.Sprints.ToList(),
                Statuses = context.Statuses.ToList()
            };

            // get Ticket objects from database based on current filters
            IQueryable<Ticket> query = context.Tickets.Include(t => t.Sprint).Include(t => t.Status);
            if (filters.HasSprint)
            {
                query = query.Where(t => t.SprintId == filters.SprintId);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            model.Tickets = query.OrderBy(t => t.SprintId).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        public IActionResult Add()
        {
            var model = new TicketViewModel
            {
                Sprints = context.Sprints.ToList(),
                Statuses = context.Statuses.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(model.CurrentTicket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                model.Sprints = context.Sprints.ToList();
                model.Statuses = context.Statuses.ToList();
                return View(model);
            }
        }
    }
}

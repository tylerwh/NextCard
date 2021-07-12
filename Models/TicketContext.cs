using Microsoft.EntityFrameworkCore;

namespace NextCard.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Name = "Backlog" },
                new Status { StatusId = 2, Name = "In Development"},
                new Status { StatusId = 3, Name = "Quality Assurance"},
                new Status { StatusId = 4, Name = "Done"}
                );
        }
    }
}

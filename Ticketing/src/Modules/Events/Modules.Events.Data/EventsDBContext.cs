using Microsoft.EntityFrameworkCore;
using Modules.Events.Data.Entities;
using Modules.Events.Data.Entities.VenueManifest;

namespace Modules.Events.Data
{
    public class EventsDBContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityOffer> ActivityOffers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatOffer> SeatOffers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public EventsDBContext(DbContextOptions<EventsDBContext> options) : base(options) 
        {
            //SavingChanges += OnSavingChanges;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(EventsDBConstants.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        //private void OnSavingChanges (object sender, SavingChangesEventArgs eventArgs)
        //{
        //    var currentDate = DateTime.UtcNow;
        //}
    }
}

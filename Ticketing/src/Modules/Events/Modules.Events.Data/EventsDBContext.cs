﻿using Microsoft.EntityFrameworkCore;
using Modules.Events.Data.Entities;
using Modules.Events.Data.Entities.VenueManifest;

namespace Modules.Events.Data
{
    public class EventsDBContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityOffer> ActivityOffers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ActivitySeatOffer> SeatOffers { get; set; }
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

        //private void OnSavingChanges(object sender, SavingChangesEventArgs eventArgs)
        //{
        //    var currentDate = DateTime.UtcNow;
        //    foreach (var entry in ChangeTracker.Entries())
        //    {
        //        if (entry.State == EntityState.Added &&
        //            entry.Entity is BaseEntity newBaseEntity)
        //        {
        //            newBaseEntity.Created = currentDate;
        //            newBaseEntity.Updated = currentDate;
        //        }
        //        else if (entry.State == EntityState.Modified &&
        //            entry.Entity is BaseEntity updatedBaseEntity)
        //        {
        //            updatedBaseEntity.Updated = currentDate;
        //        }
        //    }
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using cms_server.Models;
using System.Collections.Generic;

namespace cms_server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Niche> Niches { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Items
            var items = new List<Item>
            {
                new Item { Id = 2, Name = "Item 2" },
                new Item { Id = 3, Name = "Item 3" }
            };

            // Seed data for Buildings
            var buildings = new List<Building>
            {
                new Building { Id = 1, Name = "Tháp A" },
                new Building { Id = 2, Name = "Tháp B" }
            };

            // Seed data for Floors, Sections, and Niches
            var floors = new List<Floor>();
            var sections = new List<Section>();
            var niches = new List<Niche>();

            int floorId = 1, sectionId = 1, nicheId = 1;

            foreach (var building in buildings)
            {
                for (int f = 1; f <= 2; f++)
                {
                    floors.Add(new Floor { Id = floorId, Name = $"Floor {f}", BuildingId = building.Id });

                    for (int s = 1; s <= 8; s++)
                    {
                        sections.Add(new Section { Id = sectionId, Name = $"Section {s}", FloorId = floorId });

                        for (int n = 1; n <= 100; n++)
                        {
                            niches.Add(new Niche
                            {
                                Id = nicheId,
                                Status = (n % 10 == 0) ? "unavailable" : (n % 5 == 0) ? "booked" : "available",
                                SectionId = sectionId
                            });
                            nicheId++;
                        }

                        sectionId++;
                    }

                    floorId++;
                }
            }

            // Applying the seed data
            modelBuilder.Entity<Building>().HasData(buildings);
            modelBuilder.Entity<Floor>().HasData(floors);
            modelBuilder.Entity<Section>().HasData(sections);
            modelBuilder.Entity<Niche>().HasData(niches);
            modelBuilder.Entity<Item>().HasData(items);
        }
    }
}

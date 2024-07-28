using Halan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Halan.Infrastructure.Persistence
{
    public class HalanDbContext : DbContext
    {
        public HalanDbContext(DbContextOptions<HalanDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //// Seed data for Governorate
            //builder.Entity<Governorate>().HasData(
            //    new Governorate { Id = Guid.Parse("9ddb6f81-a2fc-40f6-86c4-537be3293f11"), DescriptionEn = "Governorate En 1", DescriptionAr = "Governorate Ar 1" },
            //    new Governorate { Id = Guid.Parse("4ab7f9e3-152d-4ed0-ac99-aef6f5f08680"), DescriptionEn = "Governorate En 2", DescriptionAr = "Governorate Ar 2" }
            //);

            //// Seed data for City
            //builder.Entity<City>().HasData(
            //    new City { Id = Guid.Parse("30d04d3c-e71a-4025-8046-c794534cde3a"), DescriptionEn = "City En 1", DescriptionAr = "City Ar 1" },
            //    new City { Id = Guid.Parse("c9bb9b66-90fb-4400-91ba-24fc00f4b411"), DescriptionEn = "City En 2", DescriptionAr = "City Ar 2" }
            //);

            //// Seed data for District
            //builder.Entity<District>().HasData(
            //    new District { Id = Guid.Parse("c37b2610-0f3b-433f-84b8-ba0e4a18cf39"), DescriptionEn = "District En 1", DescriptionAr = "District Ar 1" },
            //    new District { Id = Guid.Parse("b46c9122-f39c-4ea7-89de-ec5609a3a88a"), DescriptionEn = "District En 2", DescriptionAr = "District Ar 2" }
            //);

            base.OnModelCreating(builder);
        }
    }
}

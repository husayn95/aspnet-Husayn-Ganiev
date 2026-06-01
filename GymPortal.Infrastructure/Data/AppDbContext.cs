using GymPortal.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GymPortal.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<GymClass> Classes => Set<GymClass>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Booking>()
            .HasIndex(x => new { x.UserId, x.GymClassId })
            .IsUnique();


        builder.Entity<GymClass>().HasData(
        new GymClass
        {
            Id = 1,
            Name = "Yoga",
            Instructor = "Anna",
            Category = "Mind",
            StartTime = new DateTime(2026, 05, 30, 10, 0, 0), // better than DateTime.Now
            Capacity = 20
        },
        new GymClass
        {
            Id = 2,
            Name = "Crossfit",
            Instructor = "John",
            Category = "Strength",
            StartTime = new DateTime(2026, 06, 01, 12, 0, 0),
            Capacity = 15
        }
        );
    }

    

    
}


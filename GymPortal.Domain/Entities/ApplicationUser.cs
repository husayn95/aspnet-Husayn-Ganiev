
using Microsoft.AspNetCore.Identity;
using GymPortal.Domain.Interfaces;

namespace GymPortal.Domain.Entities;

public class ApplicationUser : IdentityUser, IUser
{
    public string FirstName { get; set; } = string.Empty;
    string? IUser.FirstName => FirstName;

    public string LastName { get; set; } = string.Empty;
    string? IUser.LastName => LastName;
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string FullName => $"{FirstName} {LastName}";

    public Membership? Membership { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

using GymPortal.Domain.Common;

namespace GymPortal.Domain.Entities;

public class GymClass : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Instructor { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public int Capacity { get; set; }

    public ICollection<Booking> Bookings { get; set; }
        = new List<Booking>();
}
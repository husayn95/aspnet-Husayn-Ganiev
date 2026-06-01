using GymPortal.Domain.Common;

namespace GymPortal.Domain.Entities;

public class Booking : BaseEntity
{
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public int GymClassId { get; set; }

    public GymClass GymClass { get; set; } = null!;

    public DateTime BookingDate { get; set; }
}
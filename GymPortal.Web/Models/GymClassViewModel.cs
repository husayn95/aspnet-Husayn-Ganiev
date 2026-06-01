using GymPortal.Domain.Entities;

public class GymClassViewModel
{
    public GymClass GymClass { get; set; } = null!;
    public bool IsBookedByUser { get; set; }
}
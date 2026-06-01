using GymPortal.Domain.Common;
using GymPortal.Domain.Enums;

namespace GymPortal.Domain.Entities;

public class Membership : BaseEntity
{
    public MembershipType Type { get; set; }

    public DateTime StartDate { get; set; }

    public bool IsActive { get; set; }

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;
}
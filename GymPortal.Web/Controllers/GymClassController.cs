using GymPortal.Domain.Entities;
using GymPortal.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers;

public class GymClassController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GymClassController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
       var classes = await _context.Classes
            .Include(x => x.Bookings)
            .ToListAsync();

        return View(classes);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Book(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var classes = await _context.Classes
                .Include(x => x.Bookings)
                .ToListAsync();

        if (classes.Any(c => c.Id == id && c.Bookings.Any(b => b.UserId == user.Id)))
        {
            TempData["Error"] = "You are already booked on this class.";
            return RedirectToAction("Index");
        }

        var booking = new Booking
        {
            GymClassId = id,
            UserId = user.Id,
            BookingDate = DateTime.UtcNow
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Class booked successfully!";
        return
        
         RedirectToAction("Index");

         var alreadyBooked = await _context.Bookings
    .AnyAsync(b => b.GymClassId == id && b.UserId == user.Id);

        if (alreadyBooked)
        {
            TempData["Error"] = "You are already booked on this class.";
            return RedirectToAction("Index");
}
    }

    
}
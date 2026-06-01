using GymPortal.Domain.Entities;
using GymPortal.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers;

[Authorize]
public class BookingController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public BookingController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var bookings = await _context.Bookings
            .Include(b => b.GymClass)
            .Where(b => b.UserId == user.Id)
            .ToListAsync();

        return View(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> Cancel(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var booking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (booking == null)
        {
            TempData["Error"] = "Booking not found.";
            return RedirectToAction("Index");
        }

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Booking cancelled.";
        return RedirectToAction("Index");
    }
}
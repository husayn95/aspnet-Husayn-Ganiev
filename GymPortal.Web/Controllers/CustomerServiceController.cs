using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GymPortal.Web.Models;

namespace GymPortal.Web.Controllers;

public class CustomerServiceController : Controller
{
    private readonly ILogger<CustomerServiceController> _logger;

    public CustomerServiceController(ILogger<CustomerServiceController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
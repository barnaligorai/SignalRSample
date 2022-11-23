using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Hubs;
using SignalRSample.Models;
using System.Diagnostics;

namespace SignalRSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<DeathlyHallowsHub> _deathlyHub;

    public HomeController(ILogger<HomeController> logger, IHubContext<DeathlyHallowsHub> deathlyHub)
    {
        _logger = logger;
        _deathlyHub = deathlyHub;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Manually added
    public async Task<IActionResult> DeathlyHallows(string type)
    {
        if (StaticDetails.DeathlyHollowRace.ContainsKey(type))
        {
            StaticDetails.DeathlyHollowRace[type]++;
        }
        await _deathlyHub.Clients.All.SendAsync("updateDeathlyHallowsCount",
            StaticDetails.DeathlyHollowRace[StaticDetails.Cloak],
            StaticDetails.DeathlyHollowRace[StaticDetails.Stone],
            StaticDetails.DeathlyHollowRace[StaticDetails.Wand]);

        return Accepted();
    }
}

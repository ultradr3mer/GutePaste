using GutePaste.Extensions;
using GutePaste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GutePaste.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var model = new StartModel() { Interval = "00:30:00" };

      return View(model);
    }

    [HttpGet(nameof(Start))]
    public IActionResult Start(StartModel model)
    {
      if (ModelState.IsValid)
      {
        return this.RedirectToAction(nameof(Session), new { Start = DateTime.UtcNow.ToUnixTimeStamp(), Interval = TimeSpan.Parse(model.Interval).TotalSeconds });
      }

      return View(nameof(Index), model);
    }

    [HttpGet(nameof(Session))]
    public IActionResult Session(long start, int interval)
    {
      var startDateTime = DateTimeExtensions.FromUnixTimeStamp(start);
      var intervalSpan = TimeSpan.FromSeconds(interval);

      var now = DateTime.UtcNow;

      var duration = now - startDateTime;
      var nextIntervalNumber = Math.Ceiling(duration / intervalSpan);
      var nextOccurence = startDateTime + intervalSpan * nextIntervalNumber;

      var model = new SessionModel() { Start = startDateTime.ToLocalTime().AddHours(2), Interval = intervalSpan, NextOccurence = nextOccurence.ToLocalTime().AddHours(2) };

      return View(model);
    }

    [HttpGet]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
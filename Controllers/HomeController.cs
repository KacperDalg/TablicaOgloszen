using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TablicaOgloszen.Data;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NewAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AdToDB(string title, string content)
    {
        var db = new NoticeBoardDBContext();
        db.Ads.Add(new AdModel
        {
            Title = title,
            Content = content,
            DateCreated = DateTime.Now
        });
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
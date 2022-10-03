using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TablicaOgloszen.Data;
using System.Linq;
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
        NoticeBoardDBContext db = new NoticeBoardDBContext();
        var data = from ad in db.Ads
                   select ad;

        AdsFromDBModel model = new AdsFromDBModel();
        model.ListOfAds = data.AsEnumerable().Where(ad => (DateTime.Now - ad.DateCreated).TotalDays <= 10.00).OrderByDescending(ad => ad.DateCreated);
        return View(model);
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
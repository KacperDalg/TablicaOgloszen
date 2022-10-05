using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TablicaOgloszen.Models;
using static TablicaOgloszen.DatabaseOperations.InsertModelToDatabaseProvider;
using static TablicaOgloszen.DatabaseOperations.PullModelFromDatabaseProvider;
using X.PagedList;

namespace TablicaOgloszen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 5;
        return View(PullAdsFromDatabase().ListOfAds.ToPagedList(pageNumber, pageSize));
    }

    public IActionResult NewAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAdToDB(string title, string content, int isOk)
    {
        if (isOk == 1 && title.Length > 0 && title.Length <= 60 && content.Length > 0 && content.Length <= 2000)
        {
            InsertAdToDatabase(title, content);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("NewAdvertisement");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
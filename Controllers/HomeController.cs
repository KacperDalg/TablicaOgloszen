using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TablicaOgloszen.Models;
using X.PagedList;
using TablicaOgloszen.DatabaseOperations;
namespace TablicaOgloszen.Controllers;

public class HomeController : Controller
{
    private IAdRepository adRepository;

    public HomeController(IAdRepository repository)
    {
        adRepository = repository;
    }

    public IActionResult Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 5;
        return View(adRepository.GetAds().ToPagedList(pageNumber, pageSize));
    }

    public IActionResult NewAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CheckAd(string title, string content)
    {
        if (title.Length > 0 && title.Length <= 60 && content.Length > 0 && content.Length <= 2000)
        {
            adRepository.InsertAd(title, content);
            adRepository.Save();
        }
        return RedirectToAction("NewAdvertisement");
    }

    protected override void Dispose(bool disposing)
    {
        adRepository.Dispose();
        base.Dispose(disposing);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
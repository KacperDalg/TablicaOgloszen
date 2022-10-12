using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TablicaOgloszen.Models;
using X.PagedList;
using TablicaOgloszen.DatabaseOperations;
using TablicaOgloszen.Data;
using ServiceStack.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TablicaOgloszen.Controllers;

public class HomeController : Controller
{
    private IAdRepository adRepository;

    public HomeController()
    {
        this.adRepository = new AdRepository(new NoticeBoardDBContext());
    }

    public IActionResult Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 5;
        return View(adRepository.GetAds().ToPagedList(pageNumber, pageSize));
    }

    [Route("Home/NewAdvertisement/{errorCode?}")]
    public IActionResult NewAdvertisement(int? errorCode)
    {
        return View();
    }

    [HttpPost]
    public IActionResult CheckAd(string title, string content, int errorCode)
    {
        if (errorCode == 0 && title.Length > 0 && title.Length <= 60 && content.Length > 0 && content.Length <= 2000)
        {
            adRepository.InsertAd(title, content);
            adRepository.Save();
        }
        return RedirectToAction("NewAdvertisement", new { errorCode = errorCode });
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
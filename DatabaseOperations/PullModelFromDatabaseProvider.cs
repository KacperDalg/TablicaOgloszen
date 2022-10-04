using TablicaOgloszen.Data;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.DatabaseOperations;

public class PullModelFromDatabaseProvider
{
    public static AdsFromDBModel PullAdsFromDatabase()
    {
        NoticeBoardDBContext db = new NoticeBoardDBContext();
        var data = from ad in db.Ads
                   select ad;

        AdsFromDBModel model = new AdsFromDBModel();
        model.ListOfAds = data.AsEnumerable().Where(ad => (DateTime.Now - ad.DateCreated).TotalDays <= 10.00).OrderByDescending(ad => ad.DateCreated);
        return model;
    }
}
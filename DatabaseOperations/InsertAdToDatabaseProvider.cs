using TablicaOgloszen.Data;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.DatabaseOperations;

public class InsertAdToDatabaseProvider
{
    public static void InsertAdToDatabase(string title, string content)
    {
        var db = new NoticeBoardDBContext();
        db.Ads.Add(new AdModel
        {
            Title = title,
            Content = content,
            DateCreated = DateTime.Now
        });
        db.SaveChanges();
    }
}
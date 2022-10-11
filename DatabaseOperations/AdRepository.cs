using TablicaOgloszen.Data;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.DatabaseOperations;

public class AdRepository : IAdRepository, IDisposable
{
    private NoticeBoardDBContext context;

    public AdRepository(NoticeBoardDBContext context)
    {
        this.context = context;
    }

    public IEnumerable<AdModel> GetAds()
    {
        return context.Ads.AsEnumerable().Where(
            ad => (DateTime.Now - ad.DateCreated).TotalDays <= 10.00).OrderByDescending(ad => ad.DateCreated
            );
    }

    public void InsertAd(string title, string content)
    {
        context.Ads.Add(new AdModel
        {
            Title = title,
            Content = content,
            DateCreated = DateTime.Now
        });
    }
    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

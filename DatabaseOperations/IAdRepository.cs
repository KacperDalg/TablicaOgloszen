using TablicaOgloszen.Models;

namespace TablicaOgloszen.DatabaseOperations;

public interface IAdRepository : IDisposable
{
    IEnumerable<AdModel> GetAds();
    void InsertAd(string title, string content);
    void Save();
}

namespace TablicaOgloszen.Models;

public class AdModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}

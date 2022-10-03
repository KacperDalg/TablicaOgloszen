using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace TablicaOgloszen.Models;

public class AdModel
{
    [Key]
    [AutoIncrement]
    public int Id { get; set; }
    [ServiceStack.DataAnnotations.Required]
    public string Title { get; set; }
    [ServiceStack.DataAnnotations.Required]
    public string Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}

using System.ComponentModel.DataAnnotations;

namespace TablicaOgloszen.Models;

public class StatisticsModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}

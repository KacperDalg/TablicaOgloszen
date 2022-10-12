using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.Data;

public class NoticeBoardDBContext : DbContext
{
    public NoticeBoardDBContext() : base()
    {

    }

    public DbSet<AdModel> Ads { get; set; }
    public DbSet<StatisticsModel> Statistics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=NoticeBoardDB;Trusted_Connection=True;");
    }
}
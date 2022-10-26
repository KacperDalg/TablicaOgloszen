using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.Data;

public class NoticeBoardDBContext : DbContext
{
    public NoticeBoardDBContext() { 

    }
    public NoticeBoardDBContext(DbContextOptions<NoticeBoardDBContext> options) : base(options)
    {

    }

    public DbSet<AdModel> Ads { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=NoticeBoardDB;Trusted_Connection=True;");
    }
}
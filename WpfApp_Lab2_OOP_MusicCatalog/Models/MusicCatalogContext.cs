using Microsoft.EntityFrameworkCore;
using System.IO;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models;

public sealed class MusicCatalogContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public MusicCatalogContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "LocalDB");
        if (!Directory.Exists(dbDirectory))
        {
            Directory.CreateDirectory(dbDirectory);
        }
        var dbPath = Path.Combine(dbDirectory, "MusicCatalogDB.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
using Microsoft.EntityFrameworkCore;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public class TrackSearchStrategy : ISearchStrategy
{
    public List<object> Search(MusicCatalogContext dbContext, string query)
    {
        return dbContext.Tracks
            .Where(t => t.Title.Contains(query))
            .Include(t => t.Album.Artist)
            .Include(t => t.Genre)
            .Cast<object>()
            .ToList();
    }
}
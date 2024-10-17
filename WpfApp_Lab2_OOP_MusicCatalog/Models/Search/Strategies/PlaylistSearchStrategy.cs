using Microsoft.EntityFrameworkCore;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public class PlaylistSearchStrategy : ISearchStrategy
{
    public List<object> Search(MusicCatalogContext dbContext, string query)
    {
        var results = dbContext.Playlists
            .Where(p => p.Title.Contains(query))
            .Include(a => a.Tracks)
            .Cast<object>()
            .ToList();

        return results;
    }
}

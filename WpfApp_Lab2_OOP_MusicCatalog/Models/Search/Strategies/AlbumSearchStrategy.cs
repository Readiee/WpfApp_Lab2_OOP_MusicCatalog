using Microsoft.EntityFrameworkCore;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public class AlbumSearchStrategy : ISearchStrategy
{
    public List<object> Search(MusicCatalogContext dbContext, string query)
    {
        return dbContext.Albums
            .Where(a => a.Title.Contains(query))
            .Include(a => a.Artist)
            .Include(a => a.Tracks)
            .Cast<object>()
            .ToList();
    }
}

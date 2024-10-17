using Microsoft.EntityFrameworkCore;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public class ArtistSearchStrategy : ISearchStrategy
{
    public List<object> Search(MusicCatalogContext dbContext, string query)
    {
        return dbContext.Artists
            .Where(a => a.Name.Contains(query))
            .Include(a => a.Albums)
            .Cast<object>()
            .ToList();
    }
}

using Microsoft.EntityFrameworkCore;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public class TrackSearchByFiltersStrategy : ISearchStrategy
{
    private string _artistName;
    private Genre _genre;
    private string _year;

    public TrackSearchByFiltersStrategy(string query, string artistName, Genre genre, string year)
    {
        _artistName = artistName;
        _genre = genre;
        _year = year;
    }

    public List<object> Search(MusicCatalogContext dbContext, string query)
    {
        return dbContext.Tracks
            .Where(t =>
                (string.IsNullOrEmpty(t.Title) || t.Title.Contains(query))
                && (string.IsNullOrEmpty(_genre.Name) || t.Genre == _genre)
                && (string.IsNullOrEmpty(_year) || t.Year.ToString() == _year)
                && (string.IsNullOrEmpty(_artistName) || t.Album.Artist.Name.Contains((_artistName)))
                )
            .Include(t => t.Genre)
            .Include(t => t.Album.Artist)
            .Cast<object>()
            .ToList();
    }
}
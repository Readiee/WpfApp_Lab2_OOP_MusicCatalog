namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Builder;

// public class AlbumBuilder : IBuilder<Album>
public class AlbumBuilder
{
    private Album _album;
    private MusicCatalogContext _dbContext;

    public AlbumBuilder(string title, int year, Artist artist, MusicCatalogContext dbContext)
    {
        _album = new Album { Title = title, Year = year, Artist = artist };
        _dbContext = dbContext;
    }

    public AlbumBuilder AddTrack(string title, int year, Genre genre)
    {
        var track = new Track { Title = title, Year = year, Genre = genre };
        _album.Tracks.Add(track);
        return this;
    }

    public Album Build()
    {
        _dbContext.Albums.Add(_album);
        _dbContext.SaveChanges();
        return _album;
    }
}

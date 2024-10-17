namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Builder;

// public class PlaylistBuilder : IBuilder<Playlist>
public class PlaylistBuilder
{
    private Playlist _playlist;
    private MusicCatalogContext _dbContext;

    public PlaylistBuilder(string title, MusicCatalogContext dbContext)
    {
        _playlist = new Playlist() { Title = title };
        _dbContext = dbContext;
    }

    public PlaylistBuilder AddTrack(Track track)
    {
        _playlist.Tracks.Add(track);
        return this;
    }

    public Playlist Build()
    {
        _dbContext.Playlists.Add(_playlist);
        _dbContext.SaveChanges();
        return _playlist;
    }
}
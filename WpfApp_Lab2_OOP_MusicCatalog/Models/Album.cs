namespace WpfApp_Lab2_OOP_MusicCatalog.Models;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public List<Track> Tracks { get; set; } = new List<Track>();
}
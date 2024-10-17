namespace WpfApp_Lab2_OOP_MusicCatalog.Models;

public class Playlist
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Track> Tracks { get; set; } = new List<Track>();
}
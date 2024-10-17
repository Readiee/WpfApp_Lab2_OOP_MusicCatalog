namespace WpfApp_Lab2_OOP_MusicCatalog.Models;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Album> Albums { get; set; } = new List<Album>();
}
using WpfApp_Lab2_OOP_MusicCatalog.Models;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

public class TrackViewModel
{
    public string Title { get; set; }
    public string ArtistInfo { get; set; }
    public string TrackInfo { get; set; }
    
    public string DisplayInfo => $"{Title} - {ArtistInfo}";

    public TrackViewModel(Track track)
    {
        Title = track.Title;
        ArtistInfo = $"{track.Album.Artist.Name}";
        TrackInfo = $"{track.Year}, {track.Genre.Name}";
    }
}

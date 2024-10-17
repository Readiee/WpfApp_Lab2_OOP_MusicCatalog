using System.Collections.ObjectModel;
using WpfApp_Lab2_OOP_MusicCatalog.Models;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

public class AlbumViewModel
{
    public string AlbumInfo { get; set; }
    public ObservableCollection<TrackViewModel> Tracks { get; set; }

    public AlbumViewModel(Album album)
    {
        AlbumInfo = $"{album.Title} ({album.Artist.Name}, {album.Year})";
        Tracks = new ObservableCollection<TrackViewModel>(album.Tracks.Select(t => new TrackViewModel(t)));
    }
}

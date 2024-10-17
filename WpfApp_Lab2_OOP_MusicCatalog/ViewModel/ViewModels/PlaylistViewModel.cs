using System.Collections.ObjectModel;
using WpfApp_Lab2_OOP_MusicCatalog.Models;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

public class PlaylistViewModel
{
    public string Title { get; set; }
    public ObservableCollection<TrackViewModel> Tracks { get; set; }

    public PlaylistViewModel(Playlist playlist)
    {
        Title = playlist.Title;
        Tracks = new ObservableCollection<TrackViewModel>(playlist.Tracks.Select(t => new TrackViewModel(t)));
    }
}

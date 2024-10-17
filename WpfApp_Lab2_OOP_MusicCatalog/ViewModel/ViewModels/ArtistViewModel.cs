using System.Collections.ObjectModel;
using WpfApp_Lab2_OOP_MusicCatalog.Models;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

public class ArtistViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ObservableCollection<Album> Albums { get; set; }

    public ArtistViewModel(Artist artist)
    {
        Id = artist.Id;
        Name = artist.Name;
        Albums = new ObservableCollection<Album>(artist.Albums);
    }
}

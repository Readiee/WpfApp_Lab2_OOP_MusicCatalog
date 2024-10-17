using System.Windows;
using System.Windows.Input;
using WpfApp_Lab2_OOP_MusicCatalog.Models;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel;

public class AddArtistViewModel : ViewModelBase
{
    private MusicCatalogContext _dbContext;

    public AddArtistViewModel(MusicCatalogContext dbContext)
    {
        _dbContext = dbContext;
    }

    private string _artistName;
    public string ArtistName
    {
        get => _artistName;
        set
        {
            _artistName = value;
            OnPropertyChanged(nameof(ArtistName));
        }
    }

    public ICommand SaveArtistCommand => new RelayCommand(SaveArtist, CanSaveArtist);
    
    private bool CanSaveArtist(object parameter)
    {
        return ArtistName != null && ArtistName.Trim() != string.Empty;
    }
    private void SaveArtist(object parameter)
    {
        if (!string.IsNullOrEmpty(ArtistName))
        {
            var artist = new Artist { Name = ArtistName.Trim() };
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
        }

        MessageBox.Show($"Исполнитель '{ArtistName}' добавлен");
        ArtistName = string.Empty;
    }
}

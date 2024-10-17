using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_Lab2_OOP_MusicCatalog.Models;
using WpfApp_Lab2_OOP_MusicCatalog.Models.Builder;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel;

public class AddSingleViewModel : ViewModelBase
{
    private MusicCatalogContext _dbContext;
    public AddSingleViewModel(MusicCatalogContext dbContext)
    {
        _dbContext = dbContext;
        Genres = new ObservableCollection<Genre>(_dbContext.Genres.ToList());
        if (Genres.Count == 0) Genres.Add(new Genre() { Name = "Жанр не определен" });
        SelectedGenre = Genres[0];
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

    private string _singleTitle;
    public string SingleTitle
    {
        get => _singleTitle;
        set
        {
            _singleTitle = value;
            OnPropertyChanged(nameof(SingleTitle));
        }
    }
    
    private string _year;
    public string Year
    {
        get => _year;
        set
        {
            _year = value;
            OnPropertyChanged(nameof(Year));
        }
    }
    
    private ObservableCollection<Genre> _genres;
    public ObservableCollection<Genre> Genres
    {
        get => _genres;
        set
        {
            _genres = value;
            OnPropertyChanged(nameof(Genres));
        }
    }

    private Genre _selectedGenre;
    public Genre SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            _selectedGenre = value;
            OnPropertyChanged(nameof(SelectedGenre));
        }
    }

    public ICommand AddSingleCommand => new RelayCommand(AddSingle, CanAddSingle);

    private bool CanAddSingle(object parameter)
    {
        return SingleTitle != null && ArtistName != null && SingleTitle.Trim() != "" && ArtistName.Trim() != "";
    }

    private void AddSingle(object parameter)
    {
        if (!string.IsNullOrEmpty(ArtistName) && !string.IsNullOrEmpty(SingleTitle))
        {
            var artist = _dbContext.Artists.FirstOrDefault(a => a.Name == ArtistName.Trim());
            if (artist == null)
            {
                artist = new Artist { Name = ArtistName.Trim() };
                _dbContext.Artists.Add(artist);
                _dbContext.SaveChanges();
            }
            
            // AlbumBuilder для создания альбома и добавления трека
            var albumBuilder = new AlbumBuilder(SingleTitle.Trim(), int.Parse(Year.Trim()), artist, _dbContext);
            albumBuilder.AddTrack(SingleTitle.Trim(), int.Parse(Year.Trim()), SelectedGenre)
                        .Build();
        
            _dbContext.SaveChanges();
        }

        MessageBox.Show($"Сингл '{ArtistName} - {SingleTitle}' добавлен");
        
        ArtistName = string.Empty;
        SingleTitle = string.Empty;
        Year = string.Empty;
        SelectedGenre = null;
        
        (parameter as Window)?.Close();
    }
}


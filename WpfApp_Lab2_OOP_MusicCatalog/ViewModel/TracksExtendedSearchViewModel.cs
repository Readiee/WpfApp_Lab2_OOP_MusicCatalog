using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp_Lab2_OOP_MusicCatalog.Models;
using WpfApp_Lab2_OOP_MusicCatalog.Models.Search;
using WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;
using WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel;

public class TracksExtendedSearchViewModel : ViewModelBase
{   
    private readonly MusicCatalogContext _dbContext;
    private readonly SearchEngine _searchEngine;
    private ObservableCollection<object> _searchResults;

    public TracksExtendedSearchViewModel(MusicCatalogContext dbContext)
    {
        _dbContext = dbContext;
        _searchEngine = new SearchEngine(new TrackSearchStrategy());
        SearchResults = new ObservableCollection<object>();
        
        Genres = new ObservableCollection<Genre>(_dbContext.Genres.ToList());
        if (Genres.Count == 0) Genres.Add(new Genre() { Name = "Жанр не определен" });
        Genres.Add(new Genre() { Name = "" });
        SelectedGenre = Genres.Last();
        
        TrackTitle = "";
        ArtistName = "";
        Year = "";
    }
    
    private string _trackTitle;
    public string TrackTitle
    {
        get => _trackTitle;
        set
        {
            _trackTitle = value;
            OnPropertyChanged(nameof(TrackTitle));
        }
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
    public ObservableCollection<object> SearchResults
    {
        get => _searchResults;
        set
        {
            _searchResults = value;
            OnPropertyChanged(nameof(SearchResults));
        }
    }
    public ICommand SearchCommand => new RelayCommand(ExecuteSearch, CanExecuteSearch);

    private bool CanExecuteSearch(object parameter)
    {
        return (TrackTitle.Trim() != string.Empty)
               || (ArtistName.Trim() != string.Empty)
               || (Year.Trim() != string.Empty)
               || SelectedGenre.Name != "";
    }
    private void ExecuteSearch(object? parameter)
    {
        _searchEngine.SetStrategy(new TrackSearchByFiltersStrategy(TrackTitle.Trim(), ArtistName.Trim(), SelectedGenre, Year.Trim()));

        SearchResults = new ObservableCollection<object>(_searchEngine
            .Search(_dbContext, TrackTitle)
            .Select(r => new TrackViewModel((Track)r)));
        
        OnPropertyChanged(nameof(SearchResults));
    }
}

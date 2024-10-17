using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_Lab2_OOP_MusicCatalog.Models;
using WpfApp_Lab2_OOP_MusicCatalog.Models.Search;
using WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;
using WpfApp_Lab2_OOP_MusicCatalog.ViewModel.ViewModels;

namespace WpfApp_Lab2_OOP_MusicCatalog.ViewModel;

public class MainViewModel : ViewModelBase
{   
    private readonly MusicCatalogContext _dbContext;
    private readonly SearchEngine _searchEngine;
    private string _query;
    private string _selectedTab;
    private ObservableCollection<object> _searchResults;

    public MainViewModel(MusicCatalogContext dbContext)
    {
        _dbContext = dbContext;
        _searchEngine = new SearchEngine(new TrackSearchStrategy());
        SelectedTab = "Треки";
        Query = "";
        SearchResults = new ObservableCollection<object>();
        ExecuteSearch(null);
    }

    public string Query
    {
        get => _query;
        set
        {
            _query = value;
            OnPropertyChanged(nameof(Query));
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
    public string SelectedTab
    {
        get => _selectedTab;
        set
        {
            _selectedTab = value;
            OnTabChanged();
            OnPropertyChanged(nameof(SelectedTab));
        }
    }

    // Изменение стратегии поиска при выборе таба
    private void OnTabChanged()
    {   
        switch (SelectedTab)
        {
            case "Треки":
                _searchEngine.SetStrategy(new TrackSearchStrategy());
                break;
            case "Альбомы":
                _searchEngine.SetStrategy(new AlbumSearchStrategy());
                break;
            case "Исполнители":
                _searchEngine.SetStrategy(new ArtistSearchStrategy());
                break;
            case "Плейлисты":
                _searchEngine.SetStrategy(new PlaylistSearchStrategy());
                break;
        }
        ExecuteSearch(null);
    }
    
    public ICommand SearchCommand => new RelayCommand(ExecuteSearch);
    private void ExecuteSearch(object? parameter)
    {
        // if (string.IsNullOrEmpty(Query)) return;
        var results = _searchEngine.Search(_dbContext, Query);
        // SearchResults = new ObservableCollection<object>(results);
        
        if (SelectedTab == "Треки")
        {
            SearchResults = new ObservableCollection<object>(
                results.Select(r => new TrackViewModel((Track)r)));
        }
        else if (SelectedTab == "Альбомы")
        {
            SearchResults = new ObservableCollection<object>(
                results.Select(r => new AlbumViewModel((Album)r)));
        }
        else if (SelectedTab == "Плейлисты")
        {
            SearchResults = new ObservableCollection<object>(
                results.Select(r => new PlaylistViewModel((Playlist)r)));
        }
        else if (SelectedTab == "Исполнители")
        {
            SearchResults = new ObservableCollection<object>(
                results.Select(r => new ArtistViewModel((Artist)r)));
        }

        OnPropertyChanged(nameof(SearchResults));
    }
    
    public ICommand AddArtist => new RelayCommand(OpenAddArtistWindow);
    private void OpenAddArtistWindow(object parameter)
    {
        var addArtistWindow = new AddArtistWindow()
        {
            DataContext = new AddArtistViewModel(_dbContext)
        };
        addArtistWindow.ShowDialog();
    }

    public ICommand AddSingle => new RelayCommand(OpenAddSingleWindow);
    private void OpenAddSingleWindow(object parameter)
    {
        var addSingleWindow = new AddSingleWindow
        {
            DataContext = new AddSingleViewModel(_dbContext)
        };
        addSingleWindow.ShowDialog();
    }
    
    public ICommand OpenTracksExtendedSearchWindowCommand => new RelayCommand(OpenTracksExtendedSearchWindow);
    private void OpenTracksExtendedSearchWindow(object parameter)
    {
        var tracksExtendedSearchWindow = new TracksExtendedSearchWindow()
        {
            DataContext = new TracksExtendedSearchViewModel(_dbContext)
        };
        tracksExtendedSearchWindow.ShowDialog();    
    }
}

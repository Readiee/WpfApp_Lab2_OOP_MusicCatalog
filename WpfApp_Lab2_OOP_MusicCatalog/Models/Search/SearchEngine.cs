using WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search;

public class SearchEngine
{
    private ISearchStrategy _searchStrategy;

    public SearchEngine(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public void SetStrategy(ISearchStrategy strategy)
    {
        _searchStrategy = strategy;
    }

    public List<object> Search(MusicCatalogContext dbContext, string query)
        => _searchStrategy?.Search(dbContext, query) ?? throw new InvalidOperationException();
}

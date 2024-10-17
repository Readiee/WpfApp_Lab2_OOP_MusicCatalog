namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Search.Strategies;

public interface ISearchStrategy
{
    List<object> Search(MusicCatalogContext dbContext, string query);
}
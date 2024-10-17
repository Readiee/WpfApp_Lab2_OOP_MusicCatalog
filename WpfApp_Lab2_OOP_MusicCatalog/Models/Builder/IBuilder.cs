namespace WpfApp_Lab2_OOP_MusicCatalog.Models.Builder;

public interface IBuilder<T>
{
    IBuilder<T> AddTrack(string title, TimeSpan duration, int year, Genre genre);
    T Build();
}

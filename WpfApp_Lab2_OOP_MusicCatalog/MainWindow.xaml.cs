using Microsoft.EntityFrameworkCore;
using System.Windows;
using WpfApp_Lab2_OOP_MusicCatalog.Models;
using WpfApp_Lab2_OOP_MusicCatalog.ViewModel;

namespace WpfApp_Lab2_OOP_MusicCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MusicCatalogContext _dbContext = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(_dbContext);
        }
    }
}
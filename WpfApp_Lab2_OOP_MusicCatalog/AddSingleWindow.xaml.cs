using System.Windows;
using System.Windows.Input;

namespace WpfApp_Lab2_OOP_MusicCatalog;

public partial class AddSingleWindow : Window
{
    public AddSingleWindow()
    {
        InitializeComponent();
    }
    
    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsTextAllowed(e.Text);
    }

    private bool IsTextAllowed(string text)
    {
        return text.All(char.IsDigit);
    }

    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Back || e.Key == Key.Delete)
        {
            e.Handled = false;
        }
    }
    
    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(DataFormats.Text))
        {
            string pastedText = (string)e.DataObject.GetData(DataFormats.Text);
            if (!IsTextAllowed(pastedText))
            {
                e.CancelCommand();
            }
        }
        else
        {
            e.CancelCommand();
        }
    }
}
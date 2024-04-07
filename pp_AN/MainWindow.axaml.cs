using Avalonia.Controls;
using Avalonia.Interactivity;

namespace pp_AN;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OpenNewWindow(object? sender, RoutedEventArgs routedEventArgs)
    {
        var newWindow = new assortment();
        newWindow.Show();
        this.Close();
    }
    private void exit(object? sender, RoutedEventArgs routedEventArgs)
    {
        this.Close();
    }
}
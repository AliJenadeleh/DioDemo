using System;
using System.Windows;

using DioDemo.Helpers;
using DioDemo.Models;
using DioDemo.Parsers;

namespace DioDemo.Windows;

/// <summary>
/// Interaction logic for ProviderWindow.xaml
/// </summary>
public partial class ProviderWindow : Window
{
    public readonly string provider_id;

    private async void LoadAsync(string ProviderId)
    {
        try
        {
            var content = await DownloadHelper.DownloadProviderAsync(ProviderId);
            var provider = DIOParser.ProviderParse(content);

            listDIO.ItemsSource = provider.meta.clients;
            lblLoading.Visibility = Visibility.Hidden;
            listDIO.Visibility = Visibility.Visible;

        }
        catch (Exception ex)
        {
            MessageBox.Show("Double Check your Internet connection and try again!!");
            this.Close();
        }
    }

    public ProviderWindow(string ProviderId)
    {
        InitializeComponent();

        this.provider_id = ProviderId;

        this.Title = $"Providers [{provider_id}]";

        this.LoadAsync(ProviderId);
    }

    private void listDIO_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (listDIO.SelectedItem != null)
        {
            var client = (ProviderClient)listDIO.SelectedItem;
            var wind = new ClientWindows(client.id);
            wind.ShowDialog();
        }
    }
}

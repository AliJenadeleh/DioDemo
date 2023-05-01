using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using DioDemo.Helpers;
using DioDemo.Parsers;

namespace DioDemo.Windows;

/// <summary>
/// Interaction logic for ClientWindows.xaml
/// </summary>
public partial class ClientWindows : Window
{
    private readonly string clientId;
    private readonly int Total;

    private async Task LoadAsync(string ProviderId, bool loadAll = false, int total = 0, CancellationToken cancellationToken = default)
    {
        btnShowAll.IsEnabled = false;
        btnShowAll.Content = "Loading...";
        try
        {
            string content;
            if (loadAll)
                content = await DownloadHelper.DownloadClientAsync(ProviderId, total, cancellationToken);
            else
                content = await DownloadHelper.DownloadClientAsync(ProviderId, cancellationToken);

            var client = DIOParser.ClientParse(content);

            listDIO.ItemsSource = client.data;
            lblLoading.Visibility = Visibility.Hidden;
            listDIO.Visibility = Visibility.Visible;

            lblTotal.Text = $"Total : {client.meta.total}";

            total = client.meta.total;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Double Check your Internet connection and try again !!");
            this.Close();
        }

        btnShowAll.Content = "Show All";
        btnShowAll.IsEnabled = true;
    }

    public ClientWindows(string ClientId)
    {
        InitializeComponent();
        clientId = ClientId;

        this.Title = $"Clients [{ClientId}]";

        LoadAsync(clientId);
    }

    private async void btnShowAll_Click(object sender, RoutedEventArgs e)
    {

        await LoadAsync(clientId);

    }
}
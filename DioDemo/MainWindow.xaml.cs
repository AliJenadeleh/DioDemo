using System.Windows;

using DioDemo.Helpers;
using DioDemo.Models;
using DioDemo.Parsers;
using DioDemo.Windows;

namespace DioDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /*
        client-id=gesis.die-gdi
        provider-id=jjuz
        consortium-id=daraco
     */
    public MainWindow()
    {
        InitializeComponent();
    }

    private static bool Validate(ConsortiumModel Consortium) => !(Consortium == null || Consortium.meta.total == 0);

    private async void btnGo_Click(object sender, RoutedEventArgs e)
    {
        btnGo.IsEnabled = false;
        btnGo.Content = "Loading...";
        if (string.IsNullOrEmpty(txtDIO.Text))
        {
            MessageBox.Show("Enter the 'DIO Consortium ID'");
            txtDIO.Focus();
        }
        else
        {
            var content = await DownloadHelperV2.DownloadConsortiumAsync(txtDIO.Text);

            var consortium = DIOParserV2.ConsortiumParse(content);

            if (consortium?.data?.Length > 0)
            {
                listDIO.ItemsSource = consortium.data;

                this.Title = $"DIO Demo By AliJenadeleh.ir ({consortium.data.Length})";
            }
            else
            {
                listDIO.ItemsSource = null;
                MessageBox.Show("Double check the Id and try again!!");
                txtDIO.Focus();
            }

        }

        btnGo.Content = "Go";
        btnGo.IsEnabled = true;
    }

    private void listDIO_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (listDIO.SelectedValue != null)
        {
            var item = (ConsortiumData)listDIO.SelectedValue;
            var wind = new ProviderWindow(item.id);
            wind.ShowDialog();
        }
    }
}

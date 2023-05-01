using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DioDemo.Helpers;

public static class DownloadHelper
{
    /*
        https://support.datacite.org/docs/api-get-lists
        client-id=gesis.die-gdi
        provider-id=jjuz
        consortium-id=daraco
     */
    private const string Base_URL = @"https://api.datacite.org";


    private static async Task<string> DownloadAsync(string URL, CancellationToken cancellationToken = default)
    {

        var handler = new HttpClientHandler()
        {
            AutomaticDecompression = System.Net.DecompressionMethods.All
        };
        var client = new HttpClient(handler);

        return await client.GetStringAsync(URL, cancellationToken);
    }


    public static async Task<string> DownloadConsortiumAsync(string ConsortiumId, CancellationToken cancellationToken = default)
    {
        return await DownloadAsync($"{Base_URL}/dois?consortium-id={ConsortiumId}", cancellationToken);
    }

    public static async Task<string> DownloadProviderAsync(string ProviderId, CancellationToken cancellationToken = default)
    {
        return await DownloadAsync($"{Base_URL}/dois?provider-id={ProviderId}", cancellationToken);
    }

    public static async Task<string> DownloadClientAsync(string ClientId, CancellationToken cancellationToken = default)
    {
        return await DownloadAsync($"{Base_URL}/dois?client_id={ClientId}", cancellationToken);
    }

    public static async Task<string> DownloadClientAsync(string ClientId, int Total, CancellationToken cancellationToken = default)
    {
        return await DownloadAsync($"{Base_URL}/dois?client-id={ClientId}&page%5Bnumber%5D=1&page%5Bsize%5D={Total}", cancellationToken);
    }

}

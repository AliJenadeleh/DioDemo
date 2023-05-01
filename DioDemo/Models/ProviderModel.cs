namespace DioDemo.Models;

public class ProviderModel
{
    public ProviderMeta meta { get; set; }
}

public class ProviderMeta
{
    public int total { get; set; }
    public int totalPages { get; set; }
    public int page { get; set; }

    public ProviderClient[] clients { get; set; }

}

public class ProviderClient
{
    public string id { get; set; }

    public string title { get; set; }

    public int count { get; set; }
}
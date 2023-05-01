namespace DioDemo.Models;

public class ConsortiumModel
{
    public ConsortiumMeta meta { get; set; }
}

public class ConsortiumMeta
{
    public int total { get; set; }
    public int totalPages { get; set; }
    public int page { get; set; }

    public ConsortiumProviderModel[] providers { get; set; }

}

public class ConsortiumProviderModel
{
    public string id { get; set; }

    public string title { get; set; }

    public int count { get; set; }
}
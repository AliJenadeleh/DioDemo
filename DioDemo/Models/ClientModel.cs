namespace DioDemo.Models;

public class ClientModel
{
    public ClientData[] data { get; set; }
    public ClientMeta meta { get; set; }
}

public class ClientMeta
{
    public int total { get; set; }
    public int totalPages { get; set; }
    public int page { get; set; }
}

public class ClientData
{
    public string id { get; set; }

    public string type { get; set; }

}
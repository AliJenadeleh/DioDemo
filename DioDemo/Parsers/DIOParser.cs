using DioDemo.Models;

using Newtonsoft.Json;

namespace DioDemo.Parsers;

public static class DIOParser
{

    public static ConsortiumModel ConsortiumParse(string Content)
    {
        return JsonConvert.DeserializeObject<ConsortiumModel>(Content);
    }

    public static ProviderModel ProviderParse(string Content)
    {
        return JsonConvert.DeserializeObject<ProviderModel>(Content);
    }

    public static ClientModel ClientParse(string Content)
    {
        return JsonConvert.DeserializeObject<ClientModel>(Content);
    }

}

using DioDemo.Models;

using Newtonsoft.Json;

namespace DioDemo.Parsers;

public static class DIOParserV2
{

    public static ConsortiumModelV2 ConsortiumParse(string Content)
    {
        return JsonConvert.DeserializeObject<ConsortiumModelV2>(Content);
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
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RickAndMorty_API_CORE.Domain.Models.ProviderJson;

public sealed class JsonProvider
{
    public static List<Character> FromJsonToCharacterList(string json)
    {
        List<Character> characters = new List<Character>();
        JObject keyValuePairs = JObject.Parse(json);
        IList<JToken> results = keyValuePairs["results"].Children().ToList();
        foreach (JToken token in results)
        {
            Character item = new Character();
            item.Id = token["id"].ToString();
            item.Name = token["name"].ToString();
            item.Status = token["status"].ToString();
            item.Species = token["species"].ToString();
            item.Gender = token["gender"].ToString();
            item.Location = token["location"]["name"].ToString();
            item.LocationUrl = token["location"]["url"].ToString();
            item.ImageUrl = token["image"].ToString();
            characters.Add(item);
        }

        return characters;
    }
    
    public static Location FromJsonToLocation(string json)
    {
        JObject keyValuePairs = JObject.Parse(json);

        Location location = new Location();
        location.Id = keyValuePairs["id"].ToString();
        location.Name = keyValuePairs["name"].ToString();
        location.Type = keyValuePairs["type"].ToString();
        location.Dimension = keyValuePairs["dimension"].ToString();
        return location;
    }

    public static int GetNumberOfPages(string json)
    {
        JObject keyValuePairs = JObject.Parse(json);
        return Int32.Parse(keyValuePairs["info"]["pages"].ToString());
    }
}
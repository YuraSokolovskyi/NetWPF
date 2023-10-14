using System.Net;

namespace RickAndMorty_API_CORE.Data.API;

public class RAM_API_ENGINE : IAPI
{
    private HttpClient _client { set; get; }
    private string _baseUri = "https://rickandmortyapi.com/api/";

    public RAM_API_ENGINE()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(_baseUri);
    }

    public string GetPage(int page)
    {
        var response = _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, _baseUri + "character?page=" + page));
        var content = response.Result.Content.ReadAsStringAsync();
        return content.Result.ToString();
    }

    public void GetCharacter(int id)
    {
        throw new NotImplementedException();
    }

    public string GetLocation(string url)
    {
        var response = _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
        var content = response.Result.Content.ReadAsStringAsync();
        return content.Result;
    }

    public void GetEpisode(int id)
    {
        throw new NotImplementedException();
    }
}
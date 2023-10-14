namespace RickAndMorty_API_CORE.Data.API;

public interface IAPI
{
    public string GetPage(int page);
    public void GetCharacter(int id);
    public string GetLocation(string url);
    public void GetEpisode(int id);
}
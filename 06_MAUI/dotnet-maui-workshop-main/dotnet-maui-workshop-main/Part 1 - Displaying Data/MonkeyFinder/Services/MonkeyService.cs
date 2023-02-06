namespace MonkeyFinder.Services;

public class MonkeyService
{
    List<Monkey> monkeyList = new();
    HttpClient httpClient;

    public MonkeyService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Monkey>> GetMonkeys()
    {
        return monkeyList;
    }
}

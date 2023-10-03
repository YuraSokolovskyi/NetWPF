using System.Net;
using System.Net.Sockets;

namespace Client;

public class Client
{
    private TcpClient _client;

    public Client(TcpClient client)
    {
        _client = client;
    }

    public async Task connect(IPEndPoint endPoint)
    {
        _client.ConnectAsync(endPoint);
    }

    public async Task writeToServer(string message)
    {
        using (StreamWriter writer = new StreamWriter(_client.GetStream(), leaveOpen:true))
        {
            await writer.WriteLineAsync(message);
        }
    }

    public async Task<string> readFromServer()
    {
        string response = "";
        using (StreamReader reader = new StreamReader(_client.GetStream(), leaveOpen:true))
        {
            response = await reader.ReadLineAsync();
        }

        return response;
    }

    public async Task<string> getQuote()
    {
        await writeToServer("GET");
        return await readFromServer();
    }
}
using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
public class Server
{
    private TcpListener _server;
    private CancellationToken _token;

    public Server(CancellationToken token){
        _token = token;
    }
    public void Start()
    {
        try
        {
            Connect();
            while (!_token.IsCancellationRequested)
            {
                Console.WriteLine("Waiting for a connection");
                AcceptClient();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception {e.Message}");
        }
        finally
        {
            Disconnect();
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }

    private void Connect()
    {
        var address = IPAddress.Parse("127.0.0.1");
        _server = new TcpListener(address, 13000);
        _server.Start();
    }

    private void Disconnect()
    {
        _server.Stop();
    }

    private void AcceptClient(){
        var client = _server.AcceptTcpClient();
        Console.WriteLine("Connected");

        Task.Run(() => new ClientWorker(client).Execute());
    }

}
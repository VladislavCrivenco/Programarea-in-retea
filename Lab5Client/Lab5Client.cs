using System;
using System.Net;
using System.Net.Sockets;
public class Lab5Client
{
    private TcpClient _client;
    private NetworkStream _stream;
    public void Start()
    {
        SayHello();
        try
        {
            Connect();
            while (true)
            {
                var input = Console.ReadLine();
                SendCommand(input);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was an error,{e.Message} press any key to exit the aplication");
            Console.ReadKey();
        }
    }

    private void Connect()
    {
        _client = new TcpClient();
        var address = IPAddress.Parse("127.0.0.1");
        _client.Connect(address, 13000);
        Console.WriteLine("You are connected, please enter a commnad");
    }

    private string SendCommand(string command)
    {
        if (_stream == null)
        {
            _stream = _client.GetStream();
        }

        command += "<EOF>";

        var requestBytes = System.Text.Encoding.ASCII.GetBytes(command);
        _stream.Write(requestBytes, 0, requestBytes.Length);

        var nr = 0;
        var result = "";
        var responseBytes = new byte[256];
        do
        {
            nr = _stream.Read(responseBytes, 0, responseBytes.Length);
            result += System.Text.Encoding.ASCII.GetString(responseBytes, 0, nr);
        }
        while (nr > 0 && !result.EndsWith("<EOF>"));

        if (result.EndsWith("<EOF>"))
        {
            result = result.Substring(0, result.Length - 5);
        }
        Console.WriteLine("Received: " + result);
        return result;
    }

    private void SayHello()
    {
        Console.WriteLine("Hello from simple client based on BSD Sockets\nPress any key to connect");
        Console.ReadKey();
    }

    private string ReadComand()
    {
        return Console.ReadLine();
    }
}
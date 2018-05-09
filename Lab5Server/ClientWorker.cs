using System;
using System.Net.Sockets;

public class ClientWorker
{
    TcpClient _client;
    NetworkStream _stream;
    public ClientWorker(TcpClient client)
    {
        _client = client;
    }

    public void Execute()
    {
        try
        {
            _stream = _client.GetStream();

            while (true)
            {
                var request = ReadCommand();
                var response = GenerateResponse(request);
                SendResponse(response);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
        finally
        {
            _stream.Close();
            _client.Close();
        }

    }

    private string ReadCommand()
    {
        var nr = 0;
        var result = "";
        var responseBytes = new byte[256];
        do
        {
            nr = _stream.Read(responseBytes, 0, responseBytes.Length);
            result += System.Text.Encoding.ASCII.GetString(responseBytes, 0, nr);

            Console.WriteLine("Received: {0}", result);
        } while (nr > 0 && !result.EndsWith("<EOF>"));

        if (result.EndsWith("<EOF>"))
        {
            result = result.Substring(0, result.Length - 5);
        }

        return result;

    }

    private string GenerateResponse(string request)
    {
        var instr = Commands.GetArgsAndCommand(request);
        switch (instr.command)
        {
            case "/help":
                return Commands.GetCommandsHelp();
            case "/time":
                return Commands.SayTime(instr.args);
            case "/hello":
                return Commands.SayHello(instr.args);
            case "/rand":
                return Commands.GetRandom(instr.args);
            case "/isprime":
                return Commands.IsPrime(instr.args);
            default:
                return Commands.InvalidCommand(instr.command);
        }
    }

    private void SendResponse(string response)
    {
        response += "<EOF>";
        byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);

        _stream.Write(msg, 0, msg.Length);
        Console.WriteLine("Sent: {0}", response);
    }
}
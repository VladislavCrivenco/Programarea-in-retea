using System.Net.Sockets;
using System.Net;
using System;
public class TcpClient
{
    private Socket _socket;
    private NetworkStream _stream;
    public void Connect(IPAddress ip, int port)
    {
        var ipEndPoint = new IPEndPoint(ip, port);
        _socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        _socket.Connect(ipEndPoint);

        if (_socket.Connected)
        {
            return;
        }

        if (_socket == null)
        {
            throw new Exception($"Could not connect to {ip}:{port}");
        }
    }

    public NetworkStream GetStream()
    {
        if (_stream == null)
        {
            _stream = new NetworkStream(_socket, true);
        }

        return _stream;
    }
}
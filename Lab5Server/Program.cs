using System;
using System.Threading.Tasks;
using System.Threading;

namespace Lab5Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var task = Task.Run(() => new Server(tokenSource.Token).Start());
            string command = "";
            while (!command.Equals("stop")){
                Console.WriteLine("Enter 'stop' to stop the server");
                command = Console.ReadLine();
                Console.WriteLine(command);
            }
            Console.WriteLine("Requested stop to the server");
            tokenSource.Cancel();
            task.Wait();
        }
    }
}

using System;
using System.Linq;

public class Commands
{
    public static (string command, string[] args) GetArgsAndCommand(string request)
    {
        var args = request.Split(" ");
        if (args.Length == 1)
        {
            return (args[0], new string[0]);
        }
        else
        {
            return (args[0], args.Skip(1).ToArray<string>());
        }
    }

    public static string GetCommandsHelp()
    {
        var response = @"Supported commands are:
            /time shows current time
            /hello says hello :)
            /rand shows a random number between some min and max value
            /isprime show if a number is a prime one";

        return response;
    }

    public static string SayHello(string[] args)
    {
        var response = "";
        foreach (var arg in args)
        {
            response = response + arg + " ";
        }

        return response;
    }

    public static string GetRandom(string[] args)
    {
        Random r = new Random();
        try
        {
            if (args.Length == 0)
            {
                return r.Next().ToString();
            }

            if (args.Length == 1)
            {
                var success = int.TryParse(args[0], out int max);
                if (!success)
                {
                    return args[0] + " is not a valid integer number";
                }
                return r.Next(max).ToString();
            }

            if (args.Length == 2)
            {
                var success = int.TryParse(args[0], out int min);
                if (!success)
                {
                    return args[0] + " is not a valid integer number";
                }

                success = int.TryParse(args[1], out int max);
                if (!success)
                {
                    return args[1] + " is not a valid integer number";
                }

                return r.Next(min, max).ToString();
            }
        }
        catch{}
        
        return "Invalid arguments";
    }

    public static string SayTime(string[] args)
    {
        return DateTime.Now.ToLongTimeString();
    }

    public static string IsPrime(string[] args)
    {
        if (args.Length == 0)
        {
            return "Please introduce a number";
        }

        var success = long.TryParse(args[0], out long nmb);
        if (!success)
        {
            return "Please introduce a valid integer number";
        }

        if (IsPrime(nmb))
        {
            return nmb + " is a prime number";
        }
        else
        {
            return nmb + " is not a prime number";
        }
    }

    private static bool IsPrime(long candidate)
    {
        // Test whether the parameter is a prime number.
        if ((candidate & 1) == 0)
        {
            if (candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Note:
        // ... This version was changed to test the square.
        // ... Original version tested against the square root.
        // ... Also we exclude 1 at the end.
        for (int i = 3; (i * i) <= candidate; i += 2)
        {
            if ((candidate % i) == 0)
            {
                return false;
            }
        }
        return candidate != 1;
    }

    public static string InvalidCommand(string request)
    {
        return $"Ouch! {request} is an invalid command\n" + GetCommandsHelp();
    }
}
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ChatClient
{
    public static void Main()
    {
        try
        {
            TcpClient tcpclnt = new();
            Console.WriteLine("Connecting.....");
            tcpclnt.Connect("192.168.0.28", 8001);
            Console.WriteLine("Connected");

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter message (type 'exit' to quit): ");
                String message = Console.ReadLine();
                if (message.ToLower() == "exit")
                    break;

                Stream stream = tcpclnt.GetStream();
                byte[] usernameBytes = Encoding.ASCII.GetBytes(username + ": ");
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                byte[] combinedBytes = new byte[usernameBytes.Length + messageBytes.Length];
                Buffer.BlockCopy(usernameBytes, 0, combinedBytes, 0, usernameBytes.Length);
                Buffer.BlockCopy(messageBytes, 0, combinedBytes, usernameBytes.Length, messageBytes.Length);

                stream.Write(combinedBytes, 0, combinedBytes.Length);
            }

            tcpclnt.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}

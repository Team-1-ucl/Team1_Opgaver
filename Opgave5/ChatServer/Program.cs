using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class ChatServer
{
    public static async Task Main()
    {
        try
        {
            IPAddress ipAd = IPAddress.Parse("192.168.0.28");
            TcpListener listener = new TcpListener(ipAd, 8001);
            listener.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("Waiting for connections...");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected to client: " + ((IPEndPoint)client.Client.RemoteEndPoint).Address);

                HandleClient(client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    private static async void HandleClient(TcpClient client)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received message from client: " + message);

                // Echo back to client
                byte[] responseBuffer = Encoding.ASCII.GetBytes("Message received by the server.");
                await stream.WriteAsync(responseBuffer, 0, responseBuffer.Length);
            }

            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error handling client: " + e.Message);
        }
    }
}

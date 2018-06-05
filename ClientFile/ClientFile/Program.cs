using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientFile
{
    class Program
    {
        private static int defaultPort = 3535;
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), defaultPort);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                Console.WriteLine("Client запущен.. ");
                Console.WriteLine("отправка сообщения");
                socket.Connect(endPoint);
                Console.WriteLine("отправте путь файла :");
                string text = @"d:\1.txt";
                //string.text = Console.ReadLine();
                socket.Send(Encoding.Default.GetBytes(text));
                Console.WriteLine("Отправлен");
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Close();
            }
            Console.ReadLine();

        }
       
    }
}

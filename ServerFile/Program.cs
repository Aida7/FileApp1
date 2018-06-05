using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerFile
{
    class Program
    {
        private static int defaultPort = 3535;
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), defaultPort);
            try
            {
                server.Start(); string newPath = @"d:\121\2.txt";

                while (true)
                {
                    Console.WriteLine("Сервер запущен..");
         
                    TcpClient client = server.AcceptTcpClient();
                    File.Move(GetClientData(client).Result, newPath);
                    Console.WriteLine("Файл перемещен и переименован");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Stop();
            }
        }

      
        public static Task<string> GetClientData(TcpClient client)
        {
            int bytes;
                using (var networkStream = client.GetStream())
                {
                  byte[] data = new byte[512];
                    do
                    {
                        bytes = networkStream.Read(data, 0, data.Length);
                        string path = Encoding.Default.GetString(data, 0, bytes);
                        return Task.Run(
                            () =>
                            {
                            return path;
                            });
                }
                    while (networkStream.DataAvailable);
                }
            
           
        }


    }

}
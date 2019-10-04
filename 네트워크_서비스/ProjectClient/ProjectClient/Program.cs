using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ProjectClient
{
    class Program
    {
        static void Main(string[] args)
        {            
            int binPort = Convert.ToInt32(args[0]);
            try
            {
                string sendMessage = string.Empty;
                IPEndPoint clientAdd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), binPort);
                IPEndPoint serverAdd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5425);

                Console.WriteLine("클라이언트 : {0}, 서버:{1}", clientAdd.ToString(), serverAdd.ToString());
                TcpClient client = new TcpClient(clientAdd);
                client.Connect(serverAdd);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write("메세지: ");
                    sendMessage = Console.ReadLine();
                    byte[] data = Encoding.Default.GetBytes(sendMessage);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("{0}Port 송신: {1}", binPort, sendMessage);

                    data = new byte[256];
                    string responseData = "";
                    int bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.Default.GetString(data, 0, bytes);
                    Console.WriteLine("{0}Port 수신: {1}", binPort, responseData);

                    if (sendMessage.ToUpper().Equals("BYE"))
                        break;                  
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace MyServerLibrary
{
    public class MyServer
    {
        Socket srvSocket = null;
        TcpListener server = null;
        StreamWriter writer;
        string logFileName = @"C:\LogService.log";
        string curTime = string.Empty;
        Thread svThread;
        public MyServer()
        {
            svThread = new Thread(new ThreadStart(ServerLoop));
            writer = new StreamWriter(logFileName, true, Encoding.Unicode);
        }
        public void ServerStart()
        {
            svThread.Start();
            writer.WriteLine("Server Open");
            writer.Flush();
        }
        public void ServerStop()
        {
            svThread.Abort();
            writer.WriteLine("Server Close");
            writer.Flush();

        }
        private void ServerLoop()
        {
            try
            {
                //서버 시작
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5425);
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5425);
                server.Start();
                ///////////////////////////
                writer.WriteLine("Server Open");
                writer.Flush();
                /// 클라이언트 호출 대기
                while (true)
                {
                    //Socket clintSocket = srvSocket.Accept();
                    //ThreadPool.QueueUserWorkItem((WaitCallback)ProcessData, clintSocket);
                    TcpClient client = server.AcceptTcpClient();                  
                    ThreadPool.QueueUserWorkItem((WaitCallback)ProcessData, client);
                 }
            }
            catch (SocketException e)
            {
                writer.WriteLine(e);
                writer.Flush();
            }
            finally
            {
                server.Stop();
            }
        }
        private void ProcessData(object state)
        {
            TcpClient client = state as TcpClient;
            int length;
            string data = null;
            string clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            byte[] bytes = new byte[256];
            writer.WriteLine("클라이언트 접속 : {0}", ((IPEndPoint)client.Client.RemoteEndPoint).ToString());
            writer.Flush();
            NetworkStream stream = client.GetStream();
          

            while (true)
            {
                length = stream.Read(bytes, 0, bytes.Length);
                data = Encoding.Default.GetString(bytes, 0, length);
                writer.WriteLine(String.Format("[{0}] 수신: {1}", clientPort, data));
                writer.Flush();
                byte[] msg = Encoding.Default.GetBytes(data);

                stream.Write(msg, 0, msg.Length);
                writer.WriteLine(String.Format("[{0}] 송신: {1}", clientPort, data));
                writer.Flush();
                if (data.ToUpper().Equals("BYE"))
                    break;
            }
            
            stream.Close();
            client.Close();
            Thread.CurrentThread.Abort();
        }
    }
}


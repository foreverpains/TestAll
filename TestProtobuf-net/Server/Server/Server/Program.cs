using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using ServerMessage;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer();
        }

        private static byte[] result;
        private const int port = 8885;

        private static Socket serverSocket;
        private static Socket clientSocket;

        public static void TcpServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            string str = "本机IP地址：" + ip;
            Console.WriteLine(str);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, port));
            serverSocket.Listen(10);
            str = "开始监听端口：" + port;
            Console.WriteLine(str);

            Thread threadAccept = new Thread(AcceptClientConnect);
            threadAccept.Start();


        }

        private static void AcceptClientConnect()
        {
            clientSocket = serverSocket.Accept();

            if (clientSocket != null)
            {
                SignUpResponse s = new SignUpResponse();
                s.errorCode = 0;
                s.version = 2;
                s.msg = System.Text.Encoding.UTF8.GetBytes("中文"); ;
                MemoryStream ms = new MemoryStream();

                ProtoBuf.Serializer.Serialize<SignUpResponse>(ms, s);

                result = ms.ToArray();
                for (int i = 0;i< result.Length;i++)
                {
                    Console.WriteLine(result[i]);
                }
                ms.Close();

                clientSocket.Send(result, result.Length, SocketFlags.None);
                string str = "长度：" + result.Length;
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }
}

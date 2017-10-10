using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using ProtoBuf;
using System.Net;
using ProtoBuf.Meta;
using ServerMessage;

public class Client : MonoBehaviour
{
    private byte[] result = new byte[1024];
    // Use this for initialization  
    void Start()
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, 8885));
            int receiveLength = clientSocket.Receive(result, result.Length, SocketFlags.None);
            Debug.Log("收到的长度receiveLength：" + receiveLength);
            Debug.Log("收到的长度result.Length：" + result.Length);
            for (int i = 0; i < receiveLength; i++)
            {
                print(result[i]);
            }
            MemoryStream ms = new MemoryStream();
            ms.Write(result, 0, receiveLength);
            ms.Position = 0;//相当重要
            SignUpResponse s = ProtoBuf.Serializer.Deserialize<SignUpResponse>(ms);
            Debug.Log("version：" + s.version);
            Debug.Log("错误代码：" + s.errorCode);
            Debug.Log("msg：" + System.Text.Encoding.UTF8.GetString(s.msg));
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using ServerMessage;

public class Test : MonoBehaviour {
    private byte[] result = new byte[1024];
	// Use this for initialization
	void Start () 
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, 8885));
            int receiveLength = clientSocket.Receive(result, result.Length, SocketFlags.None);
            Debug.Log("收到的长度："+receiveLength);
            SignUpResponse s = new SignUpResponse();
            TestType(s);
            MemoryStream ms = new MemoryStream();
            ms.Write(result, 0, receiveLength);
            s = ProtoBuf.Serializer.Deserialize<SignUpResponse>(ms);
            Debug.Log("错误代码：" + s.errorCode);  
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }
	}

    void TestType(object obj)
    {
        Debug.Log(typeof(SignUpResponse));
        Debug.Log(obj.GetType());
    }
}

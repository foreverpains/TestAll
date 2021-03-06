﻿using ProtoBuf;
using System.IO;
using System.Text;

public class ProtoBufHelper
{
    public static byte[] Serializeby(object obj)
    {
        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, obj);
            return stream.ToArray();
        }
    }
    /// <summary>
    /// 序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static string Serialize<T>(T t)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<T>(ms, t);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
    /// <summary>
    /// 反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    /// <returns></returns>
    public static T DeSerialize<T>(string content)
    {
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
        {
            T t = Serializer.Deserialize<T>(ms);
            return t;
        }
    }
}
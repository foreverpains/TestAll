using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine.Networking;

public class OutLog : MonoBehaviour
{
    static List<string> mWriteTxt = new List<string>();

    void Start()
    {
        mWriteTxt.Clear();
        Application.logMessageReceived += HandleLog;
        //一个输出
        Debug.Log("###############Start Game################");
       
    }

    void Update()
    {
        //因为写入文件的操作必须在主线程中完成，所以在Update中哦给你写入文件。
        //if (mWriteTxt.Count > 0)
        //{
        //    string[] temp = mWriteTxt.ToArray();
        //    foreach (string t in temp)
        //    {
        //        using (StreamWriter writer = new StreamWriter(m_pathName, true, Encoding.UTF8))
        //        {
        //            writer.WriteLine(t);
        //        }
        //        mWriteTxt.Remove(t);
        //    }
        //}
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        mWriteTxt.Add(logString);
    }

  
    void OnGUI()
    {
        GUI.color = Color.red;
        for (int i = 0, imax = mWriteTxt.Count; i < imax; ++i)
        {
            GUILayout.Label(mWriteTxt[i]);
        }
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }
}
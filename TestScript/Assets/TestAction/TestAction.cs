using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ProtoId
{
    Login,
    LoginOut,
    EnterMainMenu,
    EnterBattle,
    ExitBattle
}
public class TestAction : MonoBehaviour
{


    static Dictionary<ProtoId, Delegate> m_handleDict = new Dictionary<ProtoId, Delegate>();
    // Use this for initialization
    void Start()
    {
        AddEventListener(ProtoId.Login, LoginProccess);
        AddEventListener(ProtoId.LoginOut, LoginOutProccess);

        //重载
        AddEventListener<int, int>(ProtoId.EnterBattle, EnterBattleProccess);
        AddEventListener<int>(ProtoId.EnterBattle, EnterBattleProccess); //注意： Delegate 第一次赋值以后确定了类型  之后不能再添加其他重载的函数

    }

    // Update is called once per frame
    void Update()
    {
       ((Action<int,int >) m_handleDict[ProtoId.EnterBattle])(1,1);
    }

    void LoginProccess()
    {
        Debug.Log("login");
    }

    void LoginOutProccess()
    {
        Debug.Log("LoginOut");
    }

    void EnterBattleProccess(int battleID)
    {
        Debug.Log("battleID = " + battleID);
    }

    void EnterBattleProccess(int battleID,int a)
    {
        Debug.Log("battleID = " + battleID + "    a = "+ a);
    }

    void AddEventListener(ProtoId id, Action handler)
    {
        // m_handleDict[id] += handler;

        Delegate d;
        if (!m_handleDict.TryGetValue(id, out d))
        {
            m_handleDict.Add(id, null);
        }
        m_handleDict[id] = (Action)m_handleDict[id] + handler;
    }

    void AddEventListener<T>(ProtoId id, Action<T> handler)
    {
        Delegate d;
        if (!m_handleDict.TryGetValue(id, out d))
        {
            m_handleDict.Add(id, null);
        }
        m_handleDict[id] = (Action<T>)m_handleDict[id] + handler;
    }

    void AddEventListener<T, K>(ProtoId id, Action<T, K> handler)
    {
        Delegate d;
        if (!m_handleDict.TryGetValue(id, out d))
        {
            m_handleDict.Add(id, null);
        }
        m_handleDict[id] = (Action<T, K>)d + handler;
    }
}

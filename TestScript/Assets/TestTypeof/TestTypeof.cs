using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// 获得类型后，直接调用构造函数 实例化对象
/// 
/// iOS 待测试
/// 
/// iOS不支持 从字符串反射类型  如下  （但是已知类型TYPE 动态调用其构造函数 IOS 是否支持 待测试！！！） 
/// https://forum.unity3d.com/threads/c-find-and-create-objects-with-reflection-on-the-iphone.26702/
/// </summary>
public class TestTypeof : MonoBehaviour
{
    private static Dictionary<int, System.Type> dict = new Dictionary<int, System.Type>
    {
        { 0, typeof(Class0)},
        { 1, typeof(Class1)},
        { 2, typeof(Class2)}
     };


    // Use this for initialization
    void Start()
    {
        foreach (var kv in dict)
        {
            ClassBase c = CreateIntance(kv.Value);
            Debug.Log(c.ToString());

            ClassBase cp = CreateIntanceParm(kv.Value);
            Debug.Log(cp.ToString());
        }
    }


    private ClassBase CreateIntance(Type t)
    {
        ConstructorInfo ct1 = t.GetConstructor(System.Type.EmptyTypes);
        ClassBase c = (ClassBase)ct1.Invoke(null);
        return c;       
    }

    private ClassBase CreateIntanceParm(Type t)
    {
        //带参数的情况
        //定义参数类型数组
        Type[] tps = new Type[2];
        tps[0] = typeof(int);
        tps[1] = typeof(string);
        //获取类的初始化参数信息
        ConstructorInfo ct2 = t.GetConstructor(tps);

        //定义参数数组
        object[] obj = new object[2];
        obj[0] = (object)100;
        obj[1] = (object)"Param Example";

        //调用带参数的构造器
        ClassBase c = (ClassBase)ct2.Invoke(obj);
        return c;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Man
{
    刘备 = 1,
    关羽 = 2,
    张飞 = 3
}

enum Num
{
    one = 1,
    two = 2,
    three = 3
}

public class TestEnum : MonoBehaviour {


    // Use this for initialization
    void Start () {
        print(Enum.GetName(typeof(Man), 1));  //还是 刘备 (由值获取名字)

        string[] array1 = Enum.GetNames(typeof(Man));
        print(array1[1]);   //关羽

        Array array2 = Enum.GetValues(typeof(Man));
        print(array2.GetValue(1));  //还是关羽

        Type t = Enum.GetUnderlyingType(typeof(Man));
        print(t);       //输出 Int32

        //由值获取内容
        string Name = Enum.Parse(typeof(Num), "1").ToString();     //此时 Name="刘备"
        print(Name);

        //由值获取内容
        int j = Convert.ToInt32(Enum.Parse(typeof(Num), "one"));     //此时 j=2
        print(j);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

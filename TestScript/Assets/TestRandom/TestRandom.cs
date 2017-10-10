using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // 生成10个随机数
        //for (var i = 0; i < 10; i++)
        //{

        //   UnityEngine.Random.InitState(1); //设置相同的种子  则每次随机数一样
        //   float n = UnityEngine.Random.Range(0,100000);
        //   print("unity: "+n);
        //}


        //System.Random rand = new System.Random();
        //for (var i = 0; i < 10; i++)
        //{
        //    int n = rand.Next();
        //    print("one random instance: "+n);
        //}


        //for (var i = 0; i < 10; i++)
        //{
        //    int n = new System.Random().Next();
        //    print("mutl random instance: "+n);
        //}

        //for (var i = 0; i < 10; i++)
        //{
        //    int n = new System.Random(1).Next();
        //    print("mutl random instance only one seed: " + n);
        //}

        ////ps: 同一个种子会产生相同的随机序列


        //         UnityEngine.Random.InitState(1); //设置相同的种子  则每次随机数一样
        //         for (var i = 0; i < 10; i++)
        //         {           
        //             float n = UnityEngine.Random.Range(0f, 100000f);
        //             print("unity: " + n);
        //         }


        print("==================================================== ");
       
    }

    private static System.Random rand = new System.Random(378);
    public static float Range(float min, float max, string key = "defaut")
    {
        float result = (float)(rand.NextDouble() * (max - min) + min);
        return result;
    }



    // Update is called once per frame
    int index = 0;
    void Update () {
        if (index <10)
        {
            float n = rand.Next(0, 48);
            print("one random instance: " + n);
            index++;
        }
    }


    void MyRandom()
    {

    }
}

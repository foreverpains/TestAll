using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDecimal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int a = (int)(19.9 * 100);
        int b = (int)(19.9M * 100);
        print("a: " + a);
        print("b: " + b);

        double dd = 1E+22; // 10000000000000000000000d
        dd += 1;
        print("dd: " + dd);


        decimal de = (decimal)1E+22; // 10000000000000000000000d
        de += 1;
        print("de: " + de);


        //decimal 也会精度损失
        decimal ddd = 10000000000000000000000000000m;
        ddd += 0.1m;
        print("ddd: " + ddd);

        //精度损失
        double f = 66.24f * 100;
        decimal d = (66.24M * (decimal)100.0d);
        print("f: " + f);
        print("d: " + d);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

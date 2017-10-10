using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        int start = 0;
        Tween t = DOTween.To(() => start, x => start = x, 100, 1);
        t.OnUpdate(() => { Debug.Log("1:" + start); });
        t.OnUpdate(delegate { Debug.Log("2:" + start); });

        //
        List<int> list = new List<int>() { 0, 1, 0, 6, 8 };
        int[] numbers = list.ToArray();
        int count = numbers.Count(n => n % 2 == 0);
        Debug.Log("count:" + count);

        //
        var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 7);
        foreach (var i in firstNumbersLessThan6 )
        {
            Debug.Log("i:" + i);
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}

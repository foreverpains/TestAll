using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start() {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            MyFunction(10, 20.0f, new Vector3(1, 1, 1));
        });


        GetComponent<Button>().onClick.AddListener(delegate ()
        {
            MyFunction(100, 200.0f, new Vector3(1, 1, 1));
        });


        UnityAction callback = new UnityAction(MyFunction);
        GetComponent<Button>().onClick.AddListener(callback);

    }
    // Update is called once per frame
    void Update () {
		
	}


    public void MyFunction()
    {
        MyFunction(1000, 2000.0f, new Vector3(1, 1, 1));
    }
    public void MyFunction(int i, float f, Vector3 v)
    {
        print(i.ToString() + "\n" + f.ToString() + "\n" + v.ToString());
    }
}

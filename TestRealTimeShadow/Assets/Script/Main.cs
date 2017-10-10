using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public GameObject LightGo;
    public Button addBtn ,lightBtn;
    public GameObject m_orcPrefab;
	// Use this for initialization
	void Start () {
        addBtn.onClick.AddListener(AddBtnClick);
        lightBtn.onClick.AddListener(LightBtnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddBtnClick()
    {
        GameObject.Instantiate(m_orcPrefab, new Vector3(Random.Range(-10,10),0 ,Random.Range(0, 10)), Quaternion.identity);
    }

    void LightBtnClick()
    {
        LightGo.SetActive(!LightGo.activeSelf);
    }
}

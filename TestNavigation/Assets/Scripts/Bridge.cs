using UnityEngine;
using System.Collections;
using System;

public class Bridge : MonoBehaviour {

    bool isOpen = false;
    Quaternion m_roateInit;
    private float m_timeConut = 0;
	// Use this for initialization
	void Start () {
        m_timeConut = Time.time;
        m_roateInit = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - m_timeConut> 5)
        {
             isOpen = !isOpen;
             m_timeConut = Time.time;
             AgentLocomotion.open = isOpen;
        }

        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 2);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, m_roateInit, Time.deltaTime * 2);
        }
	}
}

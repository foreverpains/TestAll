using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectionMatrix : MonoBehaviour {
    private Camera camera;
    public Matrix4x4 originalProjection;
    void Update()
    {
        //改变原始矩阵的某些值  
        Matrix4x4 p = originalProjection;
        p.m01 += Mathf.Sin(Time.time * 1.2F) * 0.1F;
        p.m10 += Mathf.Sin(Time.time * 1.5F) * 0.1F;
        camera.projectionMatrix = p;
    }
    public void Awake()
    {
        camera = GetComponent<Camera>();
        originalProjection = camera.projectionMatrix;
    }
}

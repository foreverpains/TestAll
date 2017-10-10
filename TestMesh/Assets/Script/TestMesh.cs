using UnityEngine;
using System.Collections;
public class MeshImage : MonoBehaviour
{
    void Start()
    {
        MeshRectangle();
    }
    // 创建一个矩形

    void MeshRectangle()
    {
        MeshFilter mFilter = gameObject.GetComponent<MeshFilter>();
        MeshRenderer mRen = gameObject.GetComponent<MeshRenderer>();

        //矩形的四个顶点坐标

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(500, 0, 0);
        vertices[2] = new Vector3(500, 500, 0);
        vertices[3] = new Vector3(0, 500, 0);

        //三角形顶点索引

        int[] triangles = new int[6] { 0, 1, 2, 2, 3, 0 };

        //每个顶点的法线    

        Vector3[] normals = new Vector3[4];
        normals[0] = new Vector3(0, 0, -5);
        normals[1] = new Vector3(0, 0, -5);
        normals[2] = new Vector3(0, 0, -5);
        normals[3] = new Vector3(0, 0, -5);

        //UV贴图坐标

        Vector2[] uvs = new Vector2[4];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(0, 1);

        //顶点颜

        Color32[] colors32 = new Color32[4];
        colors32[0] = new Color32(255, 0, 0, 255);
        colors32[1] = new Color32(255, 0, 0, 255);
        colors32[2] = new Color32(255, 0, 0, 255);
        colors32[3] = new Color32(255, 0, 0, 255);

        Mesh mesh = new Mesh();

        mesh.hideFlags = HideFlags.DontSave;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors32 = colors32;
        mesh.uv = uvs;
        mesh.normals = normals;
        mFilter.mesh = mesh;

    }
}

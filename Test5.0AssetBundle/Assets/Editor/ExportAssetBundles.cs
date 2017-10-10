
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using System;
//using System.IO;
//public class ExportAssetBundles : Editor
//{

//    private string OUTPUT_PATH = "Asset/ab";
//    // 设置assetbundle的名字(修改meta文件)
//    [MenuItem("Tools/SetAssetBundleName")]
//    static void OnSetAssetBundleName()
//    {

//        UnityEngine.Object obj = Selection.activeObject;
//        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

//        string[] extList = new string[] { ".prefab.meta", ".png.meta", ".jpg.meta", ".tga.meta" };
//        EditorUtil.Walk(path, extList, DoSetAssetBundleName);

//        //刷新编辑器
//        AssetDatabase.Refresh();
//        Debug.Log("AssetBundleName修改完毕");
//    }

//    static void DoSetAssetBundleName(string path)
//    {
//        path = path.Replace("\\", "/");
//        int index = path.IndexOf(EditorConfig.PREFAB_PATH);
//        string relativePath = path.Substring(path.IndexOf(EditorConfig.PREFAB_PATH) + EditorConfig.PREFAB_PATH.Length);
//        string prefabName = relativePath.Substring(0, relativePath.IndexOf('.')) + EditorConfig.ASSETBUNDLE;
//        StreamReader fs = new StreamReader(path);
//        List<string> ret = new List<string>();
//        string line;
//        while ((line = fs.ReadLine()) != null)
//        {
//            line = line.Replace("\n", "");
//            if (line.IndexOf("assetBundleName:") != -1)
//            {
//                line = "  assetBundleName: " + prefabName.ToLower();

//            }
//            ret.Add(line);
//        }
//        fs.Close();

//        File.Delete(path);

//        StreamWriter writer = new StreamWriter(path + ".tmp");
//        foreach (var each in ret)
//        {
//            writer.WriteLine(each);
//        }
//        writer.Close();

//        File.Copy(path + ".tmp", path);
//        File.Delete(path + ".tmp");
//    }

//    [MenuItem("Tools/CreateAssetBundle")]
//    static void OnCreateAssetBundle()
//    {
//        BuildPipeline.BuildAssetBundles(EditorConfig.OUTPUT_PATH);

//        //刷新编辑器
//        AssetDatabase.Refresh();
//        Debug.Log("AssetBundle打包完毕");
//    }
//}
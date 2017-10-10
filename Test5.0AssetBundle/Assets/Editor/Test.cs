/************************************************
 * Test#FILEEXTENSION#
 * 项目名称：#PROJECTNAME#
 * 说明:
 * 计算机名称：#MACHINENAME#
 * 创建日期：#CREATIONDATE#
 * 作者：XiangLei
 * 版本号：V1.00
 ***********************************************/

using UnityEngine;
using System.Collections;
using UnityEditor;
public class Test : Editor
{

    [MenuItem("Tools/Export AssetBundle")]
    static void  Execute(){
        BuildPipeline.BuildAssetBundles("Assets/ab");
    }

    [MenuItem("Tool/SetFileBundleName")]
    static void SetBundleName()
    {

        #region 设置资源的AssetBundle的名称和文件扩展名
        UnityEngine.Object[] selects = Selection.objects;
        foreach (UnityEngine.Object selected in selects)
        {
            string path = AssetDatabase.GetAssetPath(selected);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            asset.assetBundleName = selected.name; //设置Bundle文件的名称
            asset.assetBundleVariant = "unity3d";//设置Bundle文件的扩展名
            asset.SaveAndReimport();

        }
        AssetDatabase.Refresh();
        #endregion
    }
}

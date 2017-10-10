/************************************************
 * TestLoadMemoy#FILEEXTENSION#
 * 项目名称：#PROJECTNAME#
 * 说明:
 * 计算机名称：#MACHINENAME#
 * 创建日期：#CREATIONDATE#
 * 作者：XiangLei
 * 版本号：V1.00
 ***********************************************/

using UnityEngine;
using System.Collections;
using System.IO;

public class TestLoadMemory : MonoBehaviour {

    //private string m_assetPath = Application.streamingAssetsPath;
    WWW www;
    Object prefab;

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "loadWWW"))
        {
            StartCoroutine(LoadAssetBundle("female", "female"));             
        }

        if (GUI.Button(new Rect(0, 50, 100, 50), "Instantiate"))
        {
            GameObject.Instantiate(prefab);
        }
        if (GUI.Button(new Rect(0, 100, 100, 50), "Unload(true)"))
        {
            //强行把assetBundle中的资源释放掉
            www.assetBundle.Unload(true);
        }

        if (GUI.Button(new Rect(0, 150, 100, 50), "Unload(false)"))
        {
            //把assetBundle中没有用到的资源释放掉
            www.assetBundle.Unload(false);
        }

        if (GUI.Button(new Rect(0, 200, 100, 50), "Dispose"))
        {
            www.Dispose();
        }

        if (GUI.Button(new Rect(0, 250, 100, 50), "UnloadUnusedAssets"))
        {
            //释放掉所有没有用到的资源
            Resources.UnloadUnusedAssets();
        }
      

    }

    public static string AB_EXTENSION = @".unity3d";
    private string text = "";
    public IEnumerator LoadAssetBundle(string prefabName, string assetBundleName)
    {
        //WWW www = null;
        string path = Application.streamingAssetsPath + "/" + GetRuntimePlatform() + "/" + prefabName + AB_EXTENSION;

        if (!File.Exists(path))
        {
            Debug.Log("the assetbundle : " + path + " is not exists!");
            yield return null;
        }

        string url = @"file://" + path;
        //Debug.Log("url : "+url);
        www = new WWW(url);

        while (!www.isDone)
        {
            text = "Load : " + assetBundleName + " progress : " + www.progress * 100 + "%";
            Debug.Log("text : " + text);
            yield return new WaitForEndOfFrame();
        }

        prefab = www.assetBundle.LoadAsset<Object>(prefabName);

       // www.assetBundle.Unload(false);
       // www.Dispose();

    }

    private string GetRuntimePlatform()
    {
        string platform = "";
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            platform = "Windows";
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            platform = "Android";
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            platform = "IOS";
        }
        else if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
        {
            platform = "OSX";
        }
        return platform;
    }
}

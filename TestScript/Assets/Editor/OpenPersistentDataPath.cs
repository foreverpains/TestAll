using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenPersistentDataPath
{
    [MenuItem("Assets/Open PresistentDataPath")]
    public static void Open()
    {
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            System.Diagnostics.Process.Start(Application.persistentDataPath);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
    }

}

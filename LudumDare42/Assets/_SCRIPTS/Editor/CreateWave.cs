using System;
using System.IO;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateWave
{
    [MenuItem("Assets/Create/Wave")]
    public static void CreateMyAsset()
    {
        Wave asset = ScriptableObject.CreateInstance<Wave>();

        AssetDatabase.CreateAsset(asset, "Assets/NewWave.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
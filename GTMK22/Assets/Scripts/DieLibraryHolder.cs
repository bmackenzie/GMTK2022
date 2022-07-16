using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEditor;


[Serializable]
public class JsonLibrary
{
    public static DieDatabase DieLibrary = DieDatabase.CreateFromJSON(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/JsonData/DieFaces.json").text);
}
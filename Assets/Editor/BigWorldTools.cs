using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class BigWorldTools
{
    [MenuItem("Tools/Big World/Rename Assets")]
    private static void RenameAssets()
    {
        GameObject landObj = GameObject.Find("Land");
        if(landObj == null)
        {
            Debug.LogError("land obj is null");
            return;
        }

        Transform[] trans = landObj.GetComponentsInChildren<Transform>();
        for(int n = 1; n < trans.Length; n++)
        {
            Transform t = trans[n];
            t.name = "Land" + (n - 1);
        }

        BWLand bwland = landObj.GetComponent<BWLand>();
        int landWidth = bwland.Width;
        int landHeight = bwland.Height;
        int i = 1;
        for(int x = 0; x < landHeight; x++)
        {
            for (int y = 0; y < landWidth; y++)
            {
                Transform t = trans[i];
                t.name = "Land" + x + "," + y;
                i++;
            }
        }
    }

    [MenuItem("Tools/Big World/SaveLand")]
    public static void SaveLand()
    {
        GameObject landObj = GameObject.Find("Land");
        BWLand bwland = landObj.GetComponent<BWLand>();
        int landWidth = bwland.Width;
        int landHeight = bwland.Height;
        int i = 1;
        Transform[] trans = landObj.GetComponentsInChildren<Transform>();

        for (int x = 0; x < landHeight; x++)
        {
            for (int y = 0; y < landWidth; y++)
            {
                Transform t = trans[i];
                t.name = "Land" + x + "," + y;

                LandOS _landOS = ScriptableObject.CreateInstance<LandOS>();
                _landOS.X = x;
                _landOS.Y = y;
                _landOS.CellSize = bwland.CellSize;
                _landOS.name = "landsX" + x + "," + y + ".asset";
                AssetDatabase.CreateAsset(_landOS, "Assets/Lands/" + _landOS.name);
                AssetDatabase.SaveAssets();

                i++;
            }
            EditorUtility.FocusProjectWindow();
        }

        //LandOS _landOS = ScriptableObject.CreateInstance<LandOS>();


    }
}

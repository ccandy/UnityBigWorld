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

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Land");
        for (int n = 1; n < gos.Length; n++)
        {
            GameObject go = gos[n];
            go.name = "Land" + (n - 1);
        }

        BWLand bwland = landObj.GetComponent<BWLand>();
        int landWidth = bwland.Width;
        int landHeight = bwland.Height;
        int i = 0;
        for(int x = 0; x < landHeight; x++)
        {
            for (int y = 0; y < landWidth; y++)
            {
                GameObject go = gos[i];
                go.name = "Land" + x + "," + y;
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
        int i = 0;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Land");

        for (int x = 0; x < landHeight; x++)
        {
            for (int y = 0; y < landWidth; y++)
            {
                GameObject go = gos[i];
                go.name = "Land" + x + "," + y;

                LandOS _landOS = ScriptableObject.CreateInstance<LandOS>();
                _landOS.X = x;
                _landOS.Y = y;
                _landOS.CellSize = bwland.CellSize;
                _landOS.name = "landsX" + x + "," + y + ".asset";
                AssetDatabase.CreateAsset(_landOS, "Assets/Lands/" + _landOS.name);
                i++;
            }
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
        }

        //LandOS _landOS = ScriptableObject.CreateInstance<LandOS>();


    }
}

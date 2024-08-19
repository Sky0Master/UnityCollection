using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;


public class SelectAllBehindZ : MonoBehaviour
{
    [MenuItem("Custom/Select All Behind Z")]
    static public void Sort()
    {

        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        float zValue;
        if(Selection.activeGameObject != null)
        {
            zValue = Selection.activeGameObject.transform.position.z;
        }
        else {return;}

        List<GameObject> res = new List<GameObject>();
        foreach(GameObject go in gameObjects)
        {
            if(go.transform.position.z > zValue)
            {
                //Debug.Log(go.name);
                res.Add(go);
            }
        }
        Selection.objects = res.ToArray();
    }
    
}

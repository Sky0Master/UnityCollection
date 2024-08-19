using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

public class ZSortEditor : MonoBehaviour
{
    [MenuItem("Custom/Sort Hierarchy by Z")]
    static public void Sort()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        Comparison<GameObject> comparison = (a, b) => a.transform.position.z.CompareTo(b.transform.position.z);
        List<GameObject> sortedGameObjects = gameObjects.ToList();
        sortedGameObjects.Sort(comparison);
        for (int i = 0; i < sortedGameObjects.Count; i++)
        {
            sortedGameObjects[i].transform.SetSiblingIndex(i);
        }
    }
    
}

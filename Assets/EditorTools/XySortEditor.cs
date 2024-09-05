using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Collections.Generic;

public class XySortEditor : MonoBehaviour
{
    [MenuItem("Custom/Sort Selection's Children by XY Position")] 
    public static void XySort()
    {
        var trans = Selection.activeGameObject.transform;
        List<Transform> children = new List<Transform>();
        for(int i = 0; i < trans.childCount; i++)
        {
            children.Add(trans.GetChild(i));
        }
        Debug.Log(trans.childCount);

        Comparison<Transform> comparison = (a, b) => { 
            if(a.position.y == b.position.y)
                return a.position.x > b.position.x ? 1:-1;
            else
                return a.position.y < b.position.y ? 1:-1;
             };
        children.Sort(comparison);
        
        for (int i = 0; i < children.Count; i++)
        {
            children[i].transform.SetSiblingIndex(i);
        }

        // Special case
        // for(int i = 2; i<children.Count; i += 4)
        // {
        //     if(i+1 >= children.Count) break;
        //     children[i].SetSiblingIndex(i+1);
        //     children[i+1].SetSiblingIndex(i);
        // }
    }
    [MenuItem("Custom/Rename Selection's Children by SiblingIndex")] 
    public static void RenameSelectChildrenBySiblingIndex()
    {
        var trans = Selection.activeGameObject.transform;
        for(int i = 0; i < trans.childCount; i++)
        {
            trans.GetChild(i).name = i.ToString();
        }
    }
}

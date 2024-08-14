using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridSprite))]
public class GridSpriteEditor : Editor
{
    GridSprite gs;
    private void OnEnable() {
        gs = target as GridSprite;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Grid"))
        {
            gs.SetGrid();
        }   
        if(GUILayout.Button("Clear"))
        {
            gs.ClearGrid();
        }    
        
    }
}

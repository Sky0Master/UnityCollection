using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridSprite : MonoBehaviour
{
    
    public int width = 2;
    public int height = 2;
    public float cellSize = 10;
    public GameObject unitPref;
    public Transform originalTrans;

    public string spritePath;
    VGrid grid;
    private void OnEnable()
    {
        
       //SetGrid();

        
    }

    
    public void ClearGrid()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
    public void SetGrid()
    {
        if (originalTrans == null) originalTrans = transform;
        grid = new VGrid(width, height, cellSize, originalTrans.position);
        grid.SetAllByPrefab(unitPref, transform);
        var sprs = Resources.LoadAll<Sprite>(spritePath);

        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
            {
                var go = grid.GetUnit(j,i);
                var index = (height - i -1) * width + j;
                //if(index < sprs.Length)
                go.GetComponent<SpriteRenderer>().sprite = sprs[index];
            }
    }
   
}

using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class VGrid
{
    protected int width;
    protected int height;
    protected float cellSize;
    protected Vector3 originalPos;
    protected Vector3 leftTop;
    protected Vector3 rightTop;
    protected Vector3 bottomLeft;
    protected GameObject[,] grid;


    public VGrid(int width, int height, float cellSize, Vector3 originalPos) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originalPos = originalPos;
        this.leftTop = originalPos + new Vector3(0, cellSize * height, 0);
        this.rightTop = originalPos + new Vector3(cellSize * width, cellSize * height, 0);
        this.bottomLeft = originalPos + new Vector3(cellSize * width, 0, 0);
        grid = new GameObject[width, height];

     
    }
    public void SetAllByPrefab(GameObject pref,Transform fa)
    {
        int t = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                GameObject unit;
                if (Application.isEditor)
                {
                    unit = PrefabUtility.InstantiatePrefab(pref, fa) as GameObject;
                }
                else
                {
                    unit = GameObject.Instantiate(pref);
                }
                SetUnit(i, j, unit);
                unit.name = t.ToString();
                t++;
            }
        }

    }
    

    public void EditorSetUnit(int x, int y, Unit unit)
    {

    }
    public void SetUnit(int x,int y, GameObject unit)
    {
        if (x>=0 &&y>=0 && x<width && y<height)
        {
            unit.transform.position = GetWorldPosition(x,y);  //adjust the unit's position to fit the grid
            grid[x, y] = unit;
        }
    }
    public void SetUnit(Vector3 worldPos, GameObject unit)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetUnit(x, y, unit);
    }
    public GameObject GetUnit(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return grid[x, y];
        }
        else
        {
            Debug.Log("Default");
            return default(GameObject);
        }
    }
        

    private void GetXY(Vector3 worldPos, out int x,out int y)
    {
        x = Mathf.FloorToInt((worldPos - originalPos).x / cellSize);
        y = Mathf.FloorToInt((worldPos - originalPos).y / cellSize);
        if(x < 0 || x > width || y < 0||y > height)
        {
            x = -1;
            y = -1;
        }
    }
    private Vector3 GetWorldPosition(int x,int y)
    {
        return (new Vector3(x,y) * cellSize) + originalPos;
    }
   
    public bool IsInsideGrid(Vector3 pos)
    {
        if (pos.x > originalPos.x && pos.x < rightTop.x && pos.y > originalPos.y && pos.y < rightTop.y)
            return true;
        else return false;

    }

}
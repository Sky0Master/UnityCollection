using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalGrid : MonoBehaviour
{

    List<GameObject> itemList;
    HorizontalLayoutGroup horizontalLayoutGroup;
    public float PosY;
    void Start()
    {
        itemList = new List<GameObject>();
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        for (int i = 0; i < transform.childCount; i++)
        {
            itemList.Add(transform.GetChild(i).gameObject);
        }
        Debug.Log("pos = "+transform.position);
        Debug.Log("RectPos = "+GetComponent<RectTransform>().position);
    }
    public void Sort()
    {
        Comparison<GameObject> comparison = (a, b) => a.transform.position.x.CompareTo(b.transform.position.x);
        itemList.Sort(comparison);
        for (int i = 0; i < itemList.Count; i++)
        {
            var item = itemList[i];
            item.transform.SetSiblingIndex(i);
            var posx =  item.transform.localPosition.x;
            item.transform.localPosition = new Vector3(posx, PosY, 0);
        }
        horizontalLayoutGroup.SetLayoutHorizontal();
    }
}

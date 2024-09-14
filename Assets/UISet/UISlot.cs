using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour
{
    public int slotType;
    public UISlotable curUISlotable;
    public GameObject selectGo;
    RectTransform rectTrans;

    public bool IsMatchType(UISlotable uISlotable)
    {
        return uISlotable.slotType == slotType;
    }

    public void AssignItem(GameObject itemGo)
    {
        if(itemGo.TryGetComponent<UISlotable>(out var uISlotable))
        {
            if(!IsMatchType(uISlotable))
                return;
            if(uISlotable.curUiSlot != null && curUISlotable != null && uISlotable != curUISlotable)
            {
                SwapSlot(uISlotable.curUiSlot,this);
            }
            curUISlotable = uISlotable;
            curUISlotable.transform.position = transform.position;
            curUISlotable.transform.SetParent(transform,false);
            
        }
    }

    public static void SwapSlot(UISlot slot1,UISlot slot2)
    {
        var item1 = slot1.curUISlotable;
        var item2 = slot2.curUISlotable;
        slot1.DetachItem();
        slot2.DetachItem();
        slot1.AssignItem(item2.gameObject);
        slot2.AssignItem(item1.gameObject);
    }

    public void DetachItem(){
        curUISlotable = null;
    }
    public void DetectOverlapRect()
    {
        var uiSlotables = GameObject.FindObjectsOfType<UISlotable>();
        selectGo?.SetActive(false);
        foreach(var uiSlotable in uiSlotables)
        {
            if(IsMatchType(uiSlotable) && RectTransformUtility.RectangleContainsScreenPoint(rectTrans , uiSlotable.transform.position))
            {
                Debug.Log(gameObject.name + " Overlap!");
                selectGo?.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectOverlapRect();
    }
}

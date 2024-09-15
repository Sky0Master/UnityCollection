using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlotable : MonoBehaviour, IDragHandler,IEndDragHandler,IBeginDragHandler
{
    public int slotType;
    public UISlot curUiSlot;
    private Vector3 startPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    private UISlot GetOverlapSlot()
    {
        var uiSlots = GameObject.FindObjectsOfType<UISlot>();
        UISlot res = null;
        foreach(UISlot slot in uiSlots)
        {
            if(slot.IsMatchType(this) && RectTransformUtility.RectangleContainsScreenPoint(slot.GetComponent<RectTransform>(),transform.position))
            {
                res = slot;
                break;
            }
        }
        return res;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        var uiSlot = GetOverlapSlot();
        if(uiSlot == null){
            transform.position = startPosition;
            return;
        }
        
        curUiSlot = uiSlot;
        curUiSlot.AssignItem(gameObject);
    }

    void Update()
    {
        
    }
}

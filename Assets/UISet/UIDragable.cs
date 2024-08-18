using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
    Transform pa;
    bool _isDragging;
    public int uId;
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(pa.parent,false);
        _isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(pa, false);
        _isDragging = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        pa = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragging)
        {
            transform.position = Input.mousePosition;
        }
    }
}

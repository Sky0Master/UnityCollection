using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class UIDragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    Transform pa;
    bool _isDragging;

    public bool isDragging {get {return _isDragging;}}

    public int uId;
    public UnityEvent endDragEvent;

    private Vector2 offset;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            _isDragging = true;
            offset = (Vector2)transform.position - eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
        endDragEvent?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }

    void Start()
    {
        pa = transform.parent;
    }


    void Update()
    {
        if (_isDragging)
        {
            transform.position = (Vector2)Input.mousePosition + offset;
        }
    }


}

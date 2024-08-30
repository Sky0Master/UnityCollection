using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISnap : MonoBehaviour
{

    public Transform snapPoint;
    public float snapDistance = 1f;

    public UIDragable uiDrag;
    
    void Update()
    {
        if (uiDrag!=null && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            transform.position = snapPoint.position;
        }
    }
}

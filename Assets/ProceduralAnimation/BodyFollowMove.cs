using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyFollowMove : MonoBehaviour
{
    public Transform prevNode;
    public float dist;
    void Start()
    {
        
    }
    private void OnDrawGizmos() {
        
    }
    Vector2 GetCorrectPosition()
    {
        Vector2 dir = transform.position - prevNode.position;
        return new Vector2(prevNode.position.x,prevNode.position.y) + dir.normalized * dist;
    }
    // Update is called once per frame
    void Update()
    {
        //if(Vector3.Distance(prevNode.position, transform.position) > dist)
        //{
            transform.position = GetCorrectPosition();
        //}
        
    }
}

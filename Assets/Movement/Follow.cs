using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 10f;
     Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate() 
    {
        var dist = target.position - transform.position;
        if(dist.magnitude > 1f)
        {
            rb.velocity = dist.normalized * followSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebound : MonoBehaviour
{
    public float reboundRatio = 1f;
    public float baseForce = 0f;
    public LayerMask reboundLayerMask;

    public float MaxReboundSpeed = 100f;
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     //Debug.Log("Rebound");
    //     // 检查碰撞物体是否在指定的层级上
    //     //if (reboundLayerMask ==  (reboundLayerMask | (1 << collision.gameObject.layer)))
    //     //{
    //         // 获取碰撞点和法线
    //         ContactPoint2D contact = collision.GetContact(0);
    //         Vector2 normal = contact.normal;
        
    //         // 计算反弹速度
    //         Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
    //         Vector2 velocity = rb.velocity;
    //         Vector2 reflectedVelocity = Vector2.Reflect(velocity, normal);
    //         // 施加反弹力
    //         rb.velocity = reflectedVelocity + reflectedVelocity.normalized * bounceForce;
    //         Debug.Log("Rebound:"+ rb.velocity);
    //     //}
    // }
    
    private void OnTriggerEnter2D(Collider2D other) {
        var rb = other.gameObject.GetComponent<Rigidbody2D>();
        var v = rb.velocity;
        
        Vector2 newV;
        if(v.magnitude < 0.1f) 
        { 
            newV = transform.up;
        }
        else{ 
            newV =  Vector2.Reflect(v,transform.up);
        }
        //newV = transform.up * v.magnitude;
        var res = newV.normalized*baseForce + newV * reboundRatio;
        rb.velocity = res;   
    }

    
    
}

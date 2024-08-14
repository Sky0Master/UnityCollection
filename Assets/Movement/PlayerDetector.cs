using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    [HideInInspector]
    public GameObject target;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰撞物体有Rigidbody2D组件
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
}

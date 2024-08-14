using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBlow : MonoBehaviour
{
     public Vector2 forceDirection = Vector2.up; // 指定方向的力
    public float forceMagnitude = 100f; // 力的大小
    public PlayerDetector detector;
   void OnMouseDown()
    {
        if(detector.target)
            detector.target.GetComponent<Rigidbody2D>().AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
    }
}

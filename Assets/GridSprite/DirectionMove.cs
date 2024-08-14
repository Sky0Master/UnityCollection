using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMove : MonoBehaviour
{
    public float Speed = 5f;
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Tile")
        {
            other.gameObject.SetActive(false);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Direction()
    {
    // 获取鼠标屏幕坐标
        Vector3 mouseScreenPos = Input.mousePosition;

        // 将屏幕坐标转换为世界坐标
        //mouseScreenPos.z = transform.position.z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = transform.position.z;
        // 计算向量
        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        // 例如：让物体朝向鼠标
        transform.up = direction;

    }
    public void Move()
    {
        rb.velocity = new Vector2(transform.up.x,transform.up.y) * Speed;
    }
    void Update()
    {
        Direction();
        Move();
    }
}

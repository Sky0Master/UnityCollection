using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


// public class Rigidbody2D : MonoBehaviour {
//     public Vector2 velocity; 
//     //xxxxxxx
// }

public class PlayerMove : MonoBehaviour
{

    SpriteRenderer spr;
    Rigidbody2D rb; 
    public float Speed;
    public float FallSpeed = 0.5f;
    public bool isGrounded;
    public float JumpForce = 10f;
    private int _hp;
    public int Hp{
        get => _hp;
        set{
            if(value<0) value = 0;
            if(value==0)
                Die();
            _hp = value;
        }
    }
    public GameObject enemy;
    public void Die()
    {

    }

    public void SetEventHandler(GameObject enem)
    {
        enem.GetComponent<Enemy>().DeathEvent += OnEnemyDie;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Blocking")
        {
            isGrounded = true;
        }
    }

    public void OnEnemyDie(object sender,GameObject target)
    {
        Debug.Log($"Enemy {target.name} Die!");
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Blocking")
        {
            isGrounded = false;
        }
    }
    
    void Update()
    {
        float xv = 0;
        if(Input.GetKey(KeyCode.D))
        {
            xv += Speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            xv -= Speed;
        }
        
        float dvy = 0;
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
            }
        }
        else{
            dvy = -FallSpeed * Time.deltaTime;
        }
        rb.velocity = new Vector2(xv, rb.velocity.y + dvy);
    }
}

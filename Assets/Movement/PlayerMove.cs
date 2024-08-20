using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// public class Rigidbody2D : MonoBehaviour {
//     public Vector2 velocity; 
//     //xxxxxxx
// }


// 0:idle   1:
public enum PlayerState
{
    Idle = 0,
    Walk = 1,
    Jump = 2,
}

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb; 
    public float Speed;
    public float FallSpeed = 0.5f;
    public bool isGrounded;
    public bool isMove;
    public float JumpForce = 10f;
    public float timeScale = 1f;
    public float groundCheckDistance = 0.5f;
    public Transform checkPoint1;
    public Transform checkPoint2;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }
/*    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Blocking")
        {
            isGrounded = true;
            animator.SetBool("grounded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Blocking")
        {
            isGrounded = false;
            animator.SetBool("grounded", true);
        }
    }*/
    private void OnDrawGizmos()
    {
        if(checkPoint1)
            Debug.DrawLine(checkPoint1.position, checkPoint1.position + Vector3.down * groundCheckDistance);
        if(checkPoint2)
            Debug.DrawLine(checkPoint2.position, checkPoint2.position + Vector3.down * groundCheckDistance);
    }
    public void GroundCheck()
    {
        var res1 = Physics2D.Raycast(checkPoint1.position,Vector2.down, groundCheckDistance,LayerMask.GetMask("Ground"));
        var res2 = Physics2D.Raycast(checkPoint2.position, Vector2.down, groundCheckDistance,LayerMask.GetMask("Ground"));

        if((res1.collider!=null) || (res2.collider!=null))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void FixedUpdate() {
        GroundCheck();
    }
    void Update()
    {
        
        Time.timeScale = timeScale;
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
                animator.SetTrigger("jump");
            }
        }
        else{
            dvy = -FallSpeed * Time.deltaTime;
        }
       
        var scaleValue = Mathf.Abs(transform.localScale.x);
        if(xv > 0.01f)
        {
            transform.localScale = new Vector3(scaleValue,scaleValue,0);
        }
        if(xv<-0.01f)
        {
            transform.localScale = new Vector3(-scaleValue, scaleValue, 0);
        }
        isMove = Mathf.Abs(xv) > 0.01f;
        animator.SetBool("is_move", isMove);
        animator.SetBool("grounded", isGrounded);
        rb.velocity = new Vector2(xv, rb.velocity.y + dvy);
    }
}

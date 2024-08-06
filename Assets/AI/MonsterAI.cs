using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public enum MonsterState
{
    Idle,
    Move,
    Attack,
}

public class MonsterAI : MonoBehaviour
{
    [HideInInspector]
    public float Hp;
    
    public float MaxHp = 100f;
    
    public float Speed = 3f;

    public MonsterState State;

    public float DetectRange = 5f;
    public float AttackRange = 1f;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
       
        Hp = MaxHp;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerObject = GameObject.Find("Player");
    }

    void IdleUpdate()
    {
        animator.SetBool("IsIdle",true);
        if(Vector2.Distance(playerObject.GetComponent<Rigidbody2D>().position, rigidBody.position) < DetectRange)
        {
            State = MonsterState.Move;
        }
    }

    void MoveUpdate()
    {
        animator.SetBool("IsMove", true);
        if(Vector2.Distance(playerObject.GetComponent<Rigidbody2D>().position, rigidBody.position) < AttackRange)
        {
            State = MonsterState.Attack;
        }

    }
    void AttackUpdate()
    {
        animator.SetBool("IsAttack", true);
        

    }
    // Update is called once per frame
    void Update()
    {
        switch(State)
        {
            case MonsterState.Idle:
                IdleUpdate();
                break;
            case MonsterState.Attack:
                AttackUpdate();
                break;
            case MonsterState.Move: 
                MoveUpdate();
                break;
        }
    }
}

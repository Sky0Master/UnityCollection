using System;

using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{

    public EventHandler<GameObject> DeathEvent;
    
    public void Die(){
        DeathEvent?.Invoke(this,gameObject);
        Destroy(this.gameObject);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Die();
        }
    }
}

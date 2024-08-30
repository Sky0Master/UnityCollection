using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public EventHandler<float> healthChangeEventHandler;
    private float _health;

    public float maxHealth = 100f;
    public float Health{
        get => _health;
        set {
            if(value < 0)
                value = 0;
            healthChangeEventHandler.Invoke(this, value / maxHealth);
            _health = value;
        }
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Health += 10;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Health -= 10;
        }
    }

}

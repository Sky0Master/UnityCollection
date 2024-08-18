using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public struct KeyBinding{
    public KeyCode key;
    public UnityEvent keyDownEvent;
}
public class KeyHandler : MonoBehaviour
{
    public KeyBinding[] keyBindings;

    void Update()
    {
        foreach(KeyBinding keyBinding in keyBindings){
            if(Input.GetKeyDown(keyBinding.key)){
                keyBinding.keyDownEvent.Invoke();
            }
        }
    }
}

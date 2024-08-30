using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIValueSlider : MonoBehaviour
{   
    public Image img;
    public PlayerHealth playerHealth;

    public void SetValue(object sender,float value)
    {
        img.fillAmount = value;
    }
    private void Start() {
        playerHealth.healthChangeEventHandler += SetValue;
    }
    private void Update() {
        
    }
}

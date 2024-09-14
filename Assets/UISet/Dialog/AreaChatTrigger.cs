using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChatTrigger : MonoBehaviour
{
    GameObject chatGo;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            chatGo.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerMove>().Die();
        }
    }
}

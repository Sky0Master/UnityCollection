using Unity.VisualScripting;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    public Transform startPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = startPoint.position;
        }
    }
}

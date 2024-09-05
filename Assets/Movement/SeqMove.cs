using System.Linq;
using UnityEngine;

public class SeqMove : MonoBehaviour
{
    public Transform[] wayPoints;
    public float moveSpeed = 1f;
    int curIndex;
    public bool isLoop = false;
    int delta;
    public bool useChildren = false;
    public Transform Pa;
    void Start()
    {
        curIndex = 0;
        delta = 1;
        if(useChildren)
        {
            wayPoints = new Transform[Pa.childCount];
            for(int i = 0; i < Pa.childCount; i++)
            {
                wayPoints[i] = Pa.GetChild(i);
            }
        }
    }

    void Update()
    {
        
        if(Vector3.Distance(transform.position, wayPoints[curIndex].position) < 0.1f)
        {
            curIndex += delta;
        }
        if(curIndex < wayPoints.Length && curIndex >= 0)
        {
           transform.position = Vector3.MoveTowards(transform.position, wayPoints[curIndex].position, moveSpeed * Time.deltaTime);
        }
        else if(isLoop) {
                delta = -delta;
                curIndex += delta;
        }
        else{
            gameObject.SetActive(false);
        }
    }
}

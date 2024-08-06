using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public string ItemName;
    public int ItemNum;
    private void OnValidate()
    {
        gameObject.name = $"{ItemName}({ItemNum})";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private float speed = 60;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (transform.position.y >= 300)
        {
            return;
        }
        transform.Translate(Vector3.up * speed*Time.fixedDeltaTime, Space.Self);
    }
}

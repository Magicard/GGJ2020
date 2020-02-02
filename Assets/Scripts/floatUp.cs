using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempPos = transform.position;
        tempPos.y += 0.1f* Time.deltaTime;
        transform.position = tempPos;
    }
}

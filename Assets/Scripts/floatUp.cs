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
        tempPos.y += 0.5f* Time.deltaTime;
        transform.position = tempPos;
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x+ 90,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z
);
    }
}

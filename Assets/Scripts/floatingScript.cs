using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingScript : MonoBehaviour
{
    public bool getBig;
    public float incSpeed= 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bigPos = new Vector3(0.76f, 0.76f, 0.76f);
        Vector3 smallPos = new Vector3(0.69f, 0.69f, 0.69f);

        if (getBig == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, bigPos, Time.deltaTime * incSpeed);
            if (transform.localScale.x >= 0.755f)
            {
                getBig = false;
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, smallPos, Time.deltaTime * incSpeed);
            if (transform.localScale.x<=0.695f)
            {
                getBig = true;
            }
        }

    }
}

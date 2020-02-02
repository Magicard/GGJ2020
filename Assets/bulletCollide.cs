using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollide : MonoBehaviour
{
    
    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.name);
        if (c.gameObject.tag == "bullet")
        {
            gameObject.GetComponent<DamagableObject>().RecieveHit(c.gameObject.GetComponent<bullet>().dmg);
            Destroy(c.gameObject);

        }
    }


}

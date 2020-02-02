using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform nose;
    public GameObject particle;

    Gun pistol;
    Gun shotgun;

    Gun currentGun;
    // Start is called before the first frame update
    void Start()
    {
        pistol = new Gun(4,10,30,0.1f);
        currentGun = pistol;


       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Gun shot");
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.up, 30000f, layerMask: LayerMask.GetMask("enemy"));

            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "enemy")
            {
                Debug.Log("Hit enemy");
                DamagableObject d = hit.collider.GetComponent<DamagableObject>();
                d.RecieveHit(currentGun.dmg);


            }

            for (int i = 0; i < 300; i++)
            {
                GameObject p = Instantiate(particle, nose.position,Quaternion.identity);
                //p.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up  * Time.deltaTime, ForceMode2D.Impulse);
            }

        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverOnMouse : MonoBehaviour
{
    public GameObject barricade;
    private Vector3 mousePosition;
    public GameObject hud;
    public float moveSpeed = 0.1f;
    public openShopScript sh;
    public buyBarrierScript br;
    public GameObject shopping;
    // Start is called before the first frame update
    void Start()
    {
        sh = GameObject.FindGameObjectWithTag("shop").GetComponent<openShopScript>(); 
        br = GameObject.FindGameObjectWithTag("button").GetComponent<buyBarrierScript>(); 

    }

    // Update is called once per frame
    void Update()
    {  
            var tempPos = transform.position;
            tempPos.z = -2f;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            tempPos = mousePosition;
            tempPos.z = -2f;
            transform.position = Vector2.Lerp(transform.position, tempPos, moveSpeed);
            var newRot = transform.rotation;
            if (Input.GetKey("q"))
            {
                newRot.z += 10f * Time.deltaTime;
                transform.rotation = newRot;

            }
            if (Input.GetKey("e"))
            {
                newRot.z -= 10f * Time.deltaTime;
                transform.rotation = newRot;
            }
        
            if (Input.GetButtonDown("Fire1") && sh.shopActive && br.amountOfBarriers>0)
            {
            Instantiate(barricade, transform.position, transform.rotation);
            br.amountOfBarriers--;
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverOnMouse : MonoBehaviour
{
    public GameObject barricade;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
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
         
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(barricade, transform.position, transform.rotation);
        }
    }
}

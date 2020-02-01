using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creationScript : MonoBehaviour
{
    public GameObject box;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(box, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position)-1f), Quaternion.identity);
        }
    }
}

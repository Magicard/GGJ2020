using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creationScript : MonoBehaviour
{
    public GameObject box;
    public bool oneInHand = false;
    public GameObject box2;
    public GameObject camera;
    public GameObject shopChoice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buyBarrierScript barrier = shopChoice.GetComponent<buyBarrierScript>();

        if (barrier.amountOfBarriers > 0)
        {
            if (oneInHand== false)
            {
                placementMode();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray2))
                    barrier.amountOfBarriers--;
            }
        }
    }

    void placementMode()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(box2, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }
}

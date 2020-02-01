using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creationScript : MonoBehaviour
{
    public GameObject box;
    public GameObject box2;
    public GameObject camera;
    public GameObject shopChoice;

    // Start is called before the first frame update
    void Start()
    {
        buyBarrierScript barrier = shopChoice.GetComponent<buyBarrierScript>();
        if (barrier.amountOfBarriers > 0)
        {
            placementMode();
        }
    }

    // Update is called once per frame
    void Update()
    {
        buyBarrierScript barrier= shopChoice.GetComponent<buyBarrierScript>();
        if (barrier.amountOfBarriers > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray2))
                    Instantiate(box, ray2.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 1f), Quaternion.identity);
            }
        }
    }

    void placementMode()
    {
        Quaternion newRot = Quaternion.Euler(90f, 0f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(box2, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), newRot);
    }
}

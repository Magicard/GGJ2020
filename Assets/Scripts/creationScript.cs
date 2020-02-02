using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creationScript : MonoBehaviour
{
    public GameObject box;
    public bool oneInHand = false;
    public GameObject barrier;
    public GameObject sentry;
    public GameObject reinforced;
    public GameObject camera;
    public GameObject shopChoice;
    public int weaponChosen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            weaponChosen = 1;
        }
        else if (Input.GetKeyDown("2"))
        {
            weaponChosen = 2;
        }
        else if (Input.GetKeyDown("3"))
        {
            weaponChosen = 3;
        }

        if (weaponChosen == 0)
        {
            buyBarrierScript barrier = shopChoice.GetComponent<buyBarrierScript>();
            if (barrier.amountOfBarriers > 0)
            {
                if (oneInHand == false)
                {
                    placementModeBarrier();
                }
            }
        }
        if(weaponChosen == 1)
        {

            buyBarrierScript barrier = shopChoice.GetComponent<buyBarrierScript>();
            if (barrier.amountOfBarriers > 0)
            {
                if (oneInHand == false)
                {
                    placementModeSentry();
                }
            }
        }
        else if (weaponChosen == 2)
        {
            buyBarrierScript barrier = shopChoice.GetComponent<buyBarrierScript>();
            if (barrier.amountOfBarriers > 0)
            {
                if (oneInHand == false)
                {
                    placementModeReinforced();
                }
            }
        }

        if (barrier.activeSelf == true && weaponChosen !=1)
        {
            Destroy(barrier);

        }
    }

    void placementModeBarrier()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(barrier, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }

    void placementModeSentry()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(sentry, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }

    void placementModeReinforced()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(reinforced, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }

    

}

    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChooser : MonoBehaviour
{
    public GameObject camera;
    public bool oneInHand = false;
    public GameObject barrier;
    public GameObject turret;
    public GameObject beattle;
    public int weaponChosen = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        


        if (Input.GetKeyDown("1"))
        {
            
            if (weaponChosen !=1)
            {
                spawnBarrier();
                weaponChosen = 1;
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            
            if (weaponChosen!=2)
            {
                spawnTurret();
                weaponChosen = 2;
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            
            if (weaponChosen!=3)
            {
                spawnBeattle();
                weaponChosen = 3;
            }
        }
        else if (Input.GetKeyDown("4"))
        {

            if (weaponChosen != 4)
            {
                spawnGun();
                weaponChosen = 4;
            }
        }
    }

    void spawnBarrier()
    {
        oneInHand = false;
        if (turret.activeSelf == true || beattle.activeSelf == true)
        {
            DestroyImmediate(GameObject.FindGameObjectWithTag("turret"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("beattle"));
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(barrier, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }
    void spawnTurret()
    {
        oneInHand = false;
        if(barrier.activeSelf ==true || beattle.activeSelf== true)
        {
            DestroyImmediate(GameObject.FindGameObjectWithTag("barrier"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("beattle"));
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(turret, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }
    void spawnBeattle()
    {
        oneInHand = false;
        if (barrier.activeSelf == true || turret.activeSelf == true)
        {
            DestroyImmediate(GameObject.FindGameObjectWithTag("barrier"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("turret"));
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Instantiate(beattle, ray.GetPoint(Vector3.Distance(camera.transform.position, transform.position) - 10f), transform.rotation);
        oneInHand = true;
    }
    void spawnGun()
    {
        oneInHand = false;
        if (barrier.activeSelf == true || turret.activeSelf == true)
        {
            DestroyImmediate(GameObject.FindGameObjectWithTag("barrier"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("turret"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("beattle"));
        }
        oneInHand = true;
    }
}

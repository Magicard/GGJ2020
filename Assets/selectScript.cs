using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectScript : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject exitBtn;
    public GameObject cameraObj;
    public GameObject newBtn;
    public bool selectOption = true;
    public bool down = false;
    public bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            down = true;
            up = false;
            selectOption = false;
        }
        if (down == true)
        {
            Vector3 newPos = new Vector3(exitBtn.transform.position.x / 7, exitBtn.transform.position.y, exitBtn.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 8f);

        }

        if (Input.GetKeyDown("w"))
        {
            up = true;
            down = false;
            selectOption = true;
        }
        if (up == true)
        {
            Vector3 newPos = new Vector3(newBtn.transform.position.x / 7, newBtn.transform.position.y, newBtn.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 8f);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (selectOption == true)
            {
                cameraObj.GetComponent<startScript>().enabled = true;
                Invoke("setGameUIActive", 7);

            }
            else if (selectOption == false)
            {
                Application.Quit();
            }
        }
        
    }

    void setGameUIActive()
    {
        gameUI.SetActive(true);
    }

}

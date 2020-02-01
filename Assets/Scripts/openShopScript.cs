using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openShopScript : MonoBehaviour
{
    public GameObject shopMenu;
    public Button yourButton;
    public bool shopActive = false;
    public GameObject shopButton;
    public GameObject shopButton2;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (shopActive == false)
        {
            Time.timeScale = 1f;
            shopActive = true;
        }
        else if (shopActive == true)
        {
            Time.timeScale = 0.2f;

            shopActive = false;
            
        }
    }

    void Update()
    {
        if (shopActive == true)
        {
            Vector3 newPos = new Vector3(shopButton.transform.position.x, shopButton.transform.position.y, shopButton.transform.position.z );
            transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * 4f);
        }
        else if (shopActive == false)
        {
            Vector3 newPos2 = new Vector3(shopButton2.transform.position.x, shopButton2.transform.position.y, shopButton2.transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPos2, Time.deltaTime * 10f);
        }
    }

    void makeFalse()
    {
        shopActive = false;
    }

    void makeTrue()
    {
        shopActive = true;
    }
}

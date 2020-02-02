using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBarrierScript : MonoBehaviour
{
    public Button yourButton;
    public int amountOfBarriers = 0;
    public int cost = 100;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (FindObjectOfType<ResourceManager>().scrap>= cost)
        {
            FindObjectOfType<ResourceManager>().SpendScrap(cost);
            amountOfBarriers += 1;
        }
        Debug.Log("yeah");
        
    }
}

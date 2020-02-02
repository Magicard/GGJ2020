using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBeetlesScript : MonoBehaviour
{
    public Button yourButton;
    public int amountOfBeetles = 0;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Debug.Log("yeah");
        amountOfBeetles += 1 ;
    }
}

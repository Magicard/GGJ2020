using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataFillScript : MonoBehaviour
{
    private Text text;
    private int counter;
    private int stringpos;
    private int stringlines;
    public string guid;

    void generateLine()
    {
        System.Guid g = System.Guid.NewGuid();
        guid = System.Convert.ToBase64String(g.ToByteArray());
        Debug.Log(guid);
        guid = guid.Replace("=", "");
        guid = guid.Replace("+", "");
    }

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        counter = 0;
        generateLine();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter <= 0)
        {
            counter = 5;
            if(stringpos<guid.Length)
            {
                text.text += guid[stringpos];
                stringpos += 1;
            }
            else
            {
                stringpos = 0;
                if (stringlines >= 4)
                {
                    text.text = "";
                    stringlines = 0;
                }
                else
                {
                    text.text += "\n";
                    stringlines += 1;
                }
                generateLine();
            }

        }
        else
        {
            counter -= 1;
        }
// text.text = "hello";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    float lastHealth = 0;
    float colourmode = 0;
    public UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = GetComponent<DamagableObject>().Health;
        if(currentHealth!=lastHealth)
        {
            //artnet colour change
            if (currentHealth > 60)
            {
                if (colourmode != 1)
                {
                    colourmode = 1;
                    GetComponent<ArtNetInterface>().SetColour(1);
                    text.color = Color.green;
                }
            }
            else
            {
                if(currentHealth > 30)
                {
                    if (colourmode!=2)
                    {
                        colourmode = 2;
                        GetComponent<ArtNetInterface>().SetColour(2);
                        text.color = Color.yellow;
                    }
                }
                else
                {
                    if (currentHealth > 10)
                    {
                        if (colourmode != 3)
                        {
                            colourmode = 3;
                            GetComponent<ArtNetInterface>().SetColour(3);
                            text.color = Color.red;
                        }
                    }
                    else
                    {
                        if (colourmode != 4)
                        {
                            colourmode = 4;
                            GetComponent<ArtNetInterface>().SetColour(4);
                            text.color = Color.red;
                        }
                    }
                }
            }

            lastHealth = currentHealth;
            text.text = string.Format("{0:000.00}%", currentHealth);
        }
    }
}

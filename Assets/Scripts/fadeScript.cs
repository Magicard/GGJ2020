using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScript : MonoBehaviour
{
    public float timer = 0;
    public GameObject text;
    public Image col1;
    public Image col2;
    public Image col3;
    public Image col4;
    public Image col5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Destroy(text);
            Destroy(col1);
            Destroy(col2);
            Destroy(col3);
            Destroy(col4);
            Destroy(col5);
        }

        timer += Time.deltaTime;
        Color oldCol = col1.color;
        Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a -= 0.5f* Time.deltaTime);
        col1.color = newCol;
        if (timer >=5 )
        {
            Color oldCol2 = col2.color;
            Color newCol2 = new Color(oldCol2.r, oldCol2.g, oldCol2.b, oldCol2.a -= 0.5f * Time.deltaTime);
            col2.color = newCol2;
            if (timer>8 )
            {
                Color oldCol3 = col3.color;
                Color newCol3 = new Color(oldCol3.r, oldCol3.g, oldCol3.b, oldCol3.a -= 0.5f * Time.deltaTime);
                col3.color = newCol3;
                if (timer> 11 )
                {
                    Color oldCol4 = col4.color;
                    Color newCol4 = new Color(oldCol4.r, oldCol4.g, oldCol4.b, oldCol4.a -= 0.5f * Time.deltaTime);
                    col4.color = newCol4;
                    if (timer > 13 )
                    {
                        Color oldCol5 = col5.color;
                        Color newCol5 = new Color(oldCol5.r, oldCol5.g, oldCol5.b, oldCol5.a -= 0.5f * Time.deltaTime);
                        col5.color = newCol5;
                        Destroy(text);
                    }
                }

            }
        }


    }
}

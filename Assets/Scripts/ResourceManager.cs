using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /// <summary>
    /// Amount of scrap collected
    /// </summary>
    public int scrap;

    public UnityEngine.UI.Text scrapCounter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectScrap(int ammount)
    {
        scrap += ammount;
        scrapCounter.text = string.Format("Scrap {0}", scrap);
    }

    public void SpendScrap(int ammount)
    {
        scrap -= ammount;
        if (scrap < 0)
            scrap = 0;
        scrapCounter.text = string.Format("Scrap {0}", scrap);
    }
}

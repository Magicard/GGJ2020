using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{

    private Text text;
    public float progress;
    public float increment;
    public float timer= 0;
    public const float finished= 150;
    public bool gameRunning;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            string progressString = string.Format("Progress {0:000.00}%", progress);
            //Debug.Log(progressString);
            text.text = progressString;
            timer += Time.deltaTime;
            progress = (timer / finished) * 100;
            //Debug.Log(progress);
            FindObjectOfType<HostileSpawner>().shouldSpawn = true;
            FindObjectOfType<HostileSpawner>().hostilecount = (int)((timer / 10) + 2);
        }
    }


}

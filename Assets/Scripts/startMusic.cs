using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMusic : MonoBehaviour
{

    public AudioSource turbo1;
    public AudioSource turbo2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            turbo1.Stop();
            turbo2.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleComponant : MonoBehaviour
{

    public BoxCollider2D col;
    public NavGrid manager;
    


    // Start is called before the first frame update
    void Start()
    {
       manager.makeObs(gameObject.gameObject);


    }

    // Update is called once per frame
    void Update()
    {

        


    }
}

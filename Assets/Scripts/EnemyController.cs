using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    bool moving = false;
    float speed = 0.5f;
    Vector3 target;
     Node[] targets;
    public int targetIndex = 0;
    int maxIndex;
    float nodeSize;
    public GameObject nav;
    public GameObject player;
    Vector3 targetTo;






    void Start()
    {
        target = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        targetTo = player.transform.position;

        getPath();


        
            
            Vector2 pos = transform.position;
            float hspd;
            float vspd;

            if (pos.x < target.x){
                hspd = speed;
            }
            else
            {
                hspd = -speed;
            }

            if(pos.y < target.y)
            {
                vspd = speed;
            }
            else
            {
                vspd = -1;
            }/*
            if (Vector3.Distance(gameObject.transform.position, target) < nodeSize)
            {
                if(targetIndex + 1 < maxIndex)
                {
                    targetIndex++;

                    target = targets[targetIndex];

                }
                else
                {
                    moving = false;
                }
            }
            */



            transform.position = new Vector3(pos.x + hspd * Time.deltaTime, pos.y + vspd * Time.deltaTime,-2);

            float angleRad = Mathf.Atan2((target.y - transform.position.y), ((target.x - transform.position.x)));
            float angle = (180 / Mathf.PI) * angleRad;
            angle -= 90;

            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);


        
        
        
    }

    

    void getPath()
    {
        Debug.Log("Getting Path");

        moving = true;
        Node[] path = nav.GetComponent<NavGrid>().findPath(transform.position, targetTo);
        
        Debug.Log("Got " + path.Length.ToString() + " Paths");

        /*
        List<Vector3> tempPos = new List<Vector3>();
        for (int i = path.Length -1; i > -1; i--)
        {
            tempPos.Add(path[i].position);
            Debug.Log(tempPos[path.Length].ToString());


        }
        */


        targets = path;
        target = targets[0].position;


    }
}

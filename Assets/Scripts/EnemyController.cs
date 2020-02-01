using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //robot objects
    public GameObject head;
    public GameObject ArmL;
    public GameObject ArmR;

    // Start is called before the first frame update

    bool moving = false;
    public float speed = 0.5f;
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



        //rotate head towards target
        Vector2 targetPositionVector = player.transform.position - head.transform.position;
        float targetAngle = Vector2.SignedAngle(transform.up, targetPositionVector);
        head.transform.localRotation = Quaternion.Slerp(head.transform.localRotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * 1);


        laserUpdate(ArmL, -15, 45);
        laserUpdate(ArmR, -45, 15);


    }

    void laserUpdate(GameObject rotationpoint,float minangle,float maxangle)
    {
        //rotate head towards target
        Vector2 targetPositionVector = player.transform.position - rotationpoint.transform.position;
        float targetAngle = Vector2.SignedAngle(transform.up, targetPositionVector);
        float limitedAngle = Mathf.Max(minangle, Mathf.Min(maxangle, targetAngle));
        rotationpoint.transform.localRotation = Quaternion.Slerp(rotationpoint.transform.localRotation, Quaternion.Euler(0, 0, limitedAngle), Time.deltaTime * 1);

        //check if should fire
        if ((rotationpoint.transform.rotation.eulerAngles.z - targetAngle) % 360 < 3 || (rotationpoint.transform.rotation.eulerAngles.z - targetAngle) % 360 > 357)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 2)
            {
                laserFire();
            }
        }
    }

    /// <summary>
    /// Triggers actions required when the turret fires
    /// </summary>
    void laserFire()
    {
        //attack
        player.GetComponent<DamagableObject>().RecieveHit(5*Time.deltaTime);
    }



    void getPath()
    {

        moving = true;
        Node[] path = nav.GetComponent<NavGrid>().findPath(transform.position, targetTo);
        

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

    public void OnDeath(UnityEngine.EventSystems.BaseEventData data)
    {
        Debug.Log("Enemy Destroyed", this);
        Destroy(this.gameObject);
    }
}

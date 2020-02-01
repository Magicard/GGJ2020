using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool moving = false;
    public float speed = 2f;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector2 pos = transform.position;
            float hspd;
            float vspd;

            if (pos.x < target.position.x){
                hspd = speed;
            }
            else
            {
                hspd = -speed;
            }

            if(pos.y < target.position.y)
            {
                vspd = speed;
            }
            else
            {
                vspd = -1;
            }
            transform.position = new Vector3(pos.x + hspd * Time.deltaTime, pos.y + vspd * Time.deltaTime,-2);

            float angleRad = Mathf.Atan2((target.position.y - transform.position.y), ((target.position.x - transform.position.x)));
            float angle = (180 / Mathf.PI) * angleRad;
            angle -= 90;

            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);


        } 
        
        
    }
}

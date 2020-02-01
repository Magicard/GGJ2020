using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public float hspd, vspd = 0;
    public float horrizontalVel = 0;
    public float verticalVel = 0;

    private float halfSpeed;
    private float fullSpeed;

    private LineRenderer lr;



    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player collided");
        if (col.gameObject.layer == 8){
            Debug.Log("Player collided");
            hspd = 0;
            vspd = 0;

        }
    }

    void Start()
    {
        halfSpeed = speed / 2;
        fullSpeed = speed;
        lr = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        horrizontalVel = Input.GetAxisRaw("Horizontal");
        verticalVel = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(horrizontalVel) > 0 && Mathf.Abs(verticalVel) > 0)
        {
            speed = halfSpeed;
        }
        else
        {
            speed = fullSpeed;
        }

        horrizontalVel *= speed;
        verticalVel *= speed;

        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + horrizontalVel * Time.deltaTime, pos.y + verticalVel * Time.deltaTime, pos.z);

        Vector3 mousePos = Input.mousePosition;
        Vector3 realMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        float AngleRad = Mathf.Atan2(realMousePos.y - gameObject.transform.position.y, realMousePos.x - gameObject.transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        float dir = Vector3.Angle(gameObject.transform.position, realMousePos);
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, angle);



        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position,gameObject.transform.right,9999,layerMask:LayerMask.GetMask("wall","enemy"));
        Vector3 hitPos = Vector3.zero;

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.layer == 8 || hit.collider.gameObject.layer == 9)
            {
                hitPos = hit.point;
            }
            else
            {
                hitPos = gameObject.transform.right * 99999;
            }
        }
        else
        {
            hitPos = gameObject.transform.right * 99999;
        }

        






        Vector3[] Positions = new Vector3[] { gameObject.transform.position, hitPos};
        Vector3[] LinePositions = new Vector3[Positions.Length];


        for (int i = 0; i < Positions.Length; i++)
        {
            Positions[i].z = gameObject.transform.position.z + 0.01f;

        }
        Color lineColor = new Color(255, 0, 0, 0.5f);
        lr.alignment = LineAlignment.TransformZ;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.sortingOrder = 0;


        

        

        lr.SetPositions(Positions);


    }

    
}

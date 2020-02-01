using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public float tranSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, 0f, transform.position.z);
        Quaternion newRot = Quaternion.Euler(0f, transform.rotation.y, transform.rotation.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * tranSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * tranSpeed);
    }
}

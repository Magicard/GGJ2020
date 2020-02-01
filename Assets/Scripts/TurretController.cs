using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject turretRotator;
    public float turretAngle;
    public float turetTranslationSpeed;
    public ParticleSystem turretFireSmoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate turret towards target
        turretRotator.transform.rotation = Quaternion.Slerp(turretRotator.transform.rotation, Quaternion.Euler(0, 0, turretAngle), Time.deltaTime * turetTranslationSpeed);
    }

    /// <summary>
    /// Triggers actions required when the turret fires
    /// </summary>
    void turretFire()
    {
        turretFireSmoke.Play();
    }
}

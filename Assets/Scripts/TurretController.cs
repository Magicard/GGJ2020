using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    //gameobjects
    public GameObject turretRotator;
    public ParticleSystem turretFireSmoke;

    //Turret Parameters
    public GameObject turretTarget;
    public float turretTranslationSpeed;
    public float turretMinFireIterval;

    public int turretAmmoMax;
    public int turretAmmo;
    public float turretHealthMax;
    public float turretHealth;

    //turret internal status
    private float turretLastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get angle to target
        Vector2 targetPositionVector = turretTarget.transform.position - transform.position;
        float targetAngle = Vector2.SignedAngle(transform.up, targetPositionVector);
        //rotate turret towards target
        turretRotator.transform.rotation = Quaternion.Slerp(turretRotator.transform.rotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * turretTranslationSpeed);

        //check if should fire
        if ((turretRotator.transform.rotation.eulerAngles.z - targetAngle) % 360 < 3 || (turretRotator.transform.rotation.eulerAngles.z - targetAngle) % 360 > 357)
        {
            if (Time.time > turretLastFireTime + turretMinFireIterval)
            {
                turretFire();
            }
        }
    }

    /// <summary>
    /// Triggers actions required when the turret fires
    /// </summary>
    void turretFire()
    {
        if (turretAmmo > 0)
        {
            turretFireSmoke.Play();
            turretAmmo -= 1;
            turretLastFireTime = Time.time;
        }
        else
        {
            //turret has no ammo (run no ammo error)
        }
    }
}

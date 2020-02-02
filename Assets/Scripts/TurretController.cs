using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    //gameobjects
    public GameObject turretRotator;
    public ParticleSystem turretFireSmoke;
    public GameObject deathPrefab;

    //Turret Parameters
    public GameObject turretTarget;
    public float turretTranslationSpeed;
    public float turretMinFireIterval;

    public int turretAmmoMax;
    public int turretAmmo;
    public float turretDamage;

    //turret internal status
    private float turretLastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turretTarget==null)
        {
            var next = FindObjectOfType<EnemyController>();
            if (next != null)
            {
                turretTarget = next.gameObject;
            }
            return;
        }
        //get angle to target
        Vector2 targetPositionVector = turretTarget.transform.position - transform.position;
        float targetAngle = Vector2.SignedAngle(transform.up, targetPositionVector);
        //rotate turret towards target
        turretRotator.transform.localRotation = Quaternion.Slerp(turretRotator.transform.localRotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * turretTranslationSpeed);

        //check if should fire
        if ((turretRotator.transform.localRotation.eulerAngles.z - targetAngle) % 360 < 3 || (turretRotator.transform.localRotation.eulerAngles.z - targetAngle) % 360 > 357)
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

            //attack
            turretTarget.GetComponent<DamagableObject>().RecieveHit(turretDamage);
        }
        else
        {
            //turret has no ammo (run no ammo error)
        }
    }

    public void turretDeath()
    {
        Debug.Log("Turret Destroyed", this);
        Destroy(this.gameObject);
        Instantiate(deathPrefab, transform.position, transform.rotation);
    }

    /// <summary>
    /// Repairs the turret using avaliable scrap
    /// </summary>
    /// <param name="maxRepair">maximum amount of repair</param>
    /// <returns>amount of scrap spent on repair</returns>
    public int getRepaired(int maxRepair)
    {
        int spent = 0;

        if (turretAmmo<turretAmmoMax)
        {
            int ammoShortage = turretAmmoMax - turretAmmo;
            if(ammoShortage<maxRepair)
            {
                maxRepair -= ammoShortage;
                turretAmmo = turretAmmoMax;
                spent += ammoShortage;
            }
            else
            {
                spent += maxRepair;
                turretAmmo += maxRepair;
                maxRepair = 0;
            }
        }

        var damageController = GetComponent<DamagableObject>();
        if (damageController.Health < damageController.HealthMax)
        {
            float healthShortage = damageController.HealthMax - damageController.Health;
            if (healthShortage < maxRepair)
            {
                maxRepair -= (int)healthShortage;
                damageController.Health = damageController.HealthMax;
                spent += (int)healthShortage;
            }
            else
            {
                spent += maxRepair;
                damageController.Health += maxRepair;
                maxRepair = 0;
            }
        }

        return spent;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class designates an object as repairable and contains the wrapper repair function
/// </summary>
public class RepairableObject : MonoBehaviour
{
    private bool repairing;
    public bool coliding;
    private float repairCounter;
    GameObject player;

    private int requiredAtStart;

    // Start is called before the first frame update
    void Start()
    {
        coliding = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (coliding== true)
        {
            Debug.Log("peepeepeepeepeepeepeepeepeepeepeepeepeepee");
            if (Input.GetKey("f"))
            {
                StartRepair();
            }
            else
            {
                StopRepair();
            }
        }

        if(repairing)
        {
            repairCounter += 5 * Time.deltaTime;
        }

        if (repairCounter > 1)
        {
            int repairSpend = (int)repairCounter;
            Repair(repairSpend);
            repairCounter -= repairSpend;
        }

        // round up any repairs when done
        if (!repairing && repairCounter>0)
        {
            Repair(1);
            repairCounter = 0;
        }
    }

    // called by the reapir action
    public void StartRepair()
    {
        repairing = true;
        requiredAtStart = RepairNeeded();
    }

    public void StopRepair()
    {
        repairing = false;
    }

    public int RepairNeeded()
    {
        int needed = 0;

        var turret = GetComponent<TurretController>();
        if(turret!=null)
        {
            needed = (turret.turretAmmoMax - turret.turretAmmo);
        }

        var health = GetComponent<DamagableObject>();
        needed += (int)(health.HealthMax - health.Health);

        return needed;
    }

    public float Progress()
    {
        if (!repairing)
        {
            return 0.0f;
        }
        else
        {
            float neededNow = (float)RepairNeeded();
            float neededStart = (float)requiredAtStart;

            float done = neededNow - neededStart;
            float percent = (done / neededStart)*100f;
            return (percent);
        }
    }

    private void Repair(int amount)
    {
        var resourceManager = FindObjectOfType<ResourceManager>();
        
        //check we can spend the scrap
        if(resourceManager.scrap<amount)
        {
            amount = resourceManager.scrap;
            if (amount == 0)
                return;
        }

        //spend the scrap
        if(GetComponent<TurretController>() != null)
        {
            //repairing a turret
            amount = GetComponent<TurretController>().getRepaired(amount);
            resourceManager.SpendScrap(amount);
        }
        else
        {
            amount = BasicHealthRepair(amount);
            resourceManager.SpendScrap(amount);
        }
    }

    int BasicHealthRepair(int maxRepair)
    {
        int spent=0;
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

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            coliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D player)
    {
        coliding = false;
    }
}

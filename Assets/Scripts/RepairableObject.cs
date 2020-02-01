using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class designates an object as repairable and contains the wrapper repair function
/// </summary>
public class RepairableObject : MonoBehaviour
{
    private bool repairing;

    private float repairCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void StopRepair()
    {
        repairing = false;
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
    }
}

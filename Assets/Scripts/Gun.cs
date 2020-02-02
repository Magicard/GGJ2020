using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun: MonoBehaviour
{
    public float dmg;
    public int ammo;
    public int maxAmmo;
    public float spread;
    public float timeBetweenShots;

    public bool canShoot = true;



    public Gun(float damage, int startAmmo,int mAmmo,float time)
    {
        this.dmg = damage;
        this.maxAmmo = mAmmo;
        this.ammo = startAmmo;
        this.timeBetweenShots = time;
    }

    

    public bool shoot(RaycastHit2D hit)
    {
        
         
        
        return true;
    }
}

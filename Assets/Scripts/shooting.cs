using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //public Transform nose;
    //public GameObject particle;

    Gun pistol;
    Gun shotgun;
    Gun minigun;


    public Gun currentGun;
    public List<Gun> guns;
    public int currentGunIndex = 0;
    public int maxGunIndex;
    public float miniGunBulSpeed = 10f;


    public GameObject miniGunBullet;

    // Start is called before the first frame update
    void Start()
    {
        guns = new List<Gun>();

        pistol = new Gun(4,10,30,0.1f,0);
        shotgun = new Gun(25,5,10,3f,0);
        minigun = new Gun(5f, 1000, 1000, 0.02f, 1,miniGunBullet);
        minigun.bullet.GetComponent<bullet>().dmg = minigun.dmg;

        currentGun = pistol;


        guns.Add(pistol);
        guns.Add(shotgun);
        guns.Add(minigun);









        maxGunIndex = guns.Count;

    }

    IEnumerator reloadGun(Gun rGun)
    {
        yield return new WaitForSeconds(rGun.timeBetweenShots);
        rGun.canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        currentGun = guns[currentGunIndex];


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if( currentGunIndex + 1 < maxGunIndex)
            {
                currentGunIndex++;
            }
            else
            {
                currentGunIndex = 0;
            }
        }
        




        if (Input.GetMouseButton(0) && currentGun.canShoot)
        {
            currentGun.canShoot = false;
            StartCoroutine(reloadGun(currentGun));


            if (currentGun.shotType == 0)
            {
                //Debug.Log("Gun shot");
                RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.up, 30000f, layerMask: LayerMask.GetMask("enemy"));

                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "enemy")
                {
                    Debug.Log("Hit enemy");
                    DamagableObject d = hit.collider.GetComponent<DamagableObject>();
                    d.RecieveHit(currentGun.dmg);


                }

                for (int i = 0; i < 300; i++)
                {
                    //GameObject p = Instantiate(particle, nose.position,Quaternion.identity);
                    //p.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up  * Time.deltaTime, ForceMode2D.Impulse);
                }
            }else if (currentGun.shotType == 1)
            {
                GameObject bul = Instantiate(currentGun.bullet, gameObject.transform.position, Quaternion.identity);
                bul.transform.rotation = Quaternion.Euler(bul.transform.rotation.x + 45f, bul.transform.rotation.y +45f, bul.transform.rotation.z + 45f);
                bul.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * miniGunBulSpeed,ForceMode2D.Impulse);
                


            }

        }
    }

    
}

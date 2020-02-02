using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject hostilePrefab;

    public int hostilecount;
    public bool shouldSpawn;

    private bool spawning;
    private float lastspawn;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        lastspawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(string.Format("{0}", getHostileCount()));
        if(getHostileCount()<hostilecount || lastspawn < (Time.time - 10))
        {
            Debug.Log("spawning attempt");
            if (spawning == false)
            {
                Invoke("SpawnHostile", Random.Range(0.0f, 5.0f));
                spawning = true;
            }
        }
    }

    int getHostileCount()
    {
        var hostiles = FindObjectsOfType<EnemyController>();
        return hostiles.Length;
    }

    void SpawnHostile()
    {
        int pointID = Random.Range(0, spawnPoints.Length);
        Debug.Log(string.Format("spawning enemy at {0}",pointID));
        var hostile = GameObject.Instantiate(hostilePrefab, spawnPoints[pointID].transform);
        hostile.GetComponent<EnemyController>().nav = FindObjectsOfType<NavGrid>()[0].gameObject;
        spawning = false;
        lastspawn = Time.time;
    }
}

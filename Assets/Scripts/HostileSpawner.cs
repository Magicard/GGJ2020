﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject hostilePrefab;

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
        if(getHostileCount()<2 || lastspawn < (Time.time - 10))
        {
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
        hostile.GetComponent<EnemyController>().player = FindObjectsOfType<TurretController>()[0].gameObject;
        spawning = false;
        lastspawn = Time.time;
    }
}
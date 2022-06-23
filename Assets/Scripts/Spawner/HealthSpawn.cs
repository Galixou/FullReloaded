using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    public GameObject spawnee;
    float timeToSpawn = 15f;
    float currentTimetoSpawn;
    float maxObjects = 1;
    [HideInInspector]
    public float currentNumObject = 0;

    void Start()
    {
        currentTimetoSpawn = timeToSpawn;
    }

    private void Update()
    {
        if(currentTimetoSpawn > 0 && currentNumObject < maxObjects)
        {
            currentTimetoSpawn -= Time.deltaTime;
        }
        else
        {
            if (currentNumObject < maxObjects)
            {
                SpawnObject();
                currentNumObject++;
                currentTimetoSpawn = timeToSpawn;
            }
        }
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}

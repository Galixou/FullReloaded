using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    PlayerController player;
    HealthSpawn spawner;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawner = FindObjectOfType<HealthSpawn>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        player.health += Random.Range(20f, 35f);
        spawner.currentNumObject--;
        Destroy(gameObject);
    }
    
}

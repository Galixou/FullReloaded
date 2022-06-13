using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        if (player.health > 0)
        {
            Instantiate(spawnee, transform.position, transform.rotation);

            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}

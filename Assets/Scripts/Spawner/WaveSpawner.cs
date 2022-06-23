using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { WAITING };
    public SpawnState state;

    public int waveCount = 1;

    public float spawnRate = 1f;
    public float timeBetweenWaves = 5f;

    public int enemyCount;

    public float waveCountdown;
    float searchCountdown = 1f;

    public GameObject enemy;
    PlayerController player;

    public GameObject transition;
    public CanvasGroup transitionCanvas;

    public Transform[] spawnPoints;

    bool fadeIn = false;
    bool waveIsDone = true;

    // Use this for initialization
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        player = FindObjectOfType<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (waveIsDone && waveCountdown <= 0f)
        {
            StartCoroutine(waveSpawner());
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

        if (waveCountdown <= 0f)
        {
            waveCountdown = 0f;
        }

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                waveIsDone = true;
                if (!transition.activeInHierarchy)
                {
                    transition.SetActive(true);
                    transitionCanvas.alpha = 1f;
                    waveCountdown = timeBetweenWaves;
                }
                return;
            }
            else
            {
                return;
            }
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        if (player.health > 0f)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Transform _sp;

                if (waveCount < 10)
                {
                    _sp = spawnPoints[Random.Range(0, 4)];
                }
                else
                {
                    _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

                }

                GameObject enemyClone = Instantiate(enemy, _sp.position, _sp.rotation);

                yield return new WaitForSeconds(spawnRate);
            }
        }

        spawnRate -= .1f;

        if (spawnRate <= .1f)
        {
            spawnRate = .1f;
        }

        enemyCount += 2;
        waveCount++;

        state = SpawnState.WAITING;

        yield break;
    }
}
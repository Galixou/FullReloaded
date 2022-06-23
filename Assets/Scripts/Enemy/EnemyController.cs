using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 3f;

    Transform target;
    NavMeshAgent agent;
    PlayerController player;
    Pistol pistol;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();
        pistol = FindObjectOfType<Pistol>();
    }

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance && player.health > 0f)
            {
                FaceTarget();
                
                if(!alreadyAttacked)
                {
                    pistol.damage = Random.Range(3f, 5f);
                    pistol.range = Random.Range(7f, 70f);

                    pistol.Shoot();

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

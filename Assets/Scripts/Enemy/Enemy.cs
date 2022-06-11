using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    private float health = 100f;
    private float maxHealth = 100f;

    public int score = 100000;

    public AudioSource Death;
    public AudioSource Melee;

    public MeleeAttack scriptMelee;
    public Gun         scriptGun;

    public GameObject healthBarUI;
    public Slider slider;

    public Animator anim;

    public float lookRadius = 3f;

    Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        anim = GetComponent<Animator>();

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                FaceTarget();
            }
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee" && scriptMelee.anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            Melee.Play();
            anim.Play("EnemyHit");
            health -= scriptMelee.degats;

            if(floatingTextPrefab && health > 0)
            {
                ShowFloatingTextMelee();
            }

            healthBarUI.SetActive(true);
            slider.value = CalculateHealth();

            if (health <= 0)
            {
                Death.Play();
                Destroy(gameObject);
                ScoreManager.instance.Addpoint(score);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.Play("EnemyHit");

        if (floatingTextPrefab && health > 0)
        {
            ShowFloatingTextGun();
        }

        healthBarUI.SetActive(true);
        slider.value = CalculateHealth();

        if (health <= 0)
        {
            Death.Play();
            Destroy(gameObject);
            ScoreManager.instance.Addpoint(score);
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    void ShowFloatingTextMelee()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + scriptMelee.degats.ToString("F1");
    }

    void ShowFloatingTextGun()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + scriptGun.damage.ToString("F1");
    }
}

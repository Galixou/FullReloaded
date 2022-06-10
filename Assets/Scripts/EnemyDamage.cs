using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
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

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        anim = GetComponent<Animator>();
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
        go.GetComponent<TextMeshPro>().text = "-" + Mathf.Round(scriptMelee.degats * 10.0f) * 0.1f;
    }

    void ShowFloatingTextGun()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + Mathf.Round(scriptGun.damage * 10.0f) * 0.1f;
    }
}

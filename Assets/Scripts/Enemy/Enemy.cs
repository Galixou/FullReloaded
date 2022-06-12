using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    private float health = 100f;
    private float maxHealth = 100f;

    public int score = 100000;

    public AudioSource Melee;
    public AudioSource Death;

    MeleeAttack scriptMelee;

    public GameObject healthBarUI;
    public Slider slider;

    //Animator anim;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        //anim = GetComponent<Animator>();

        scriptMelee = FindObjectOfType<MeleeAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee" && scriptMelee.anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            Melee.Play();
            //anim.Play("EnemyHit");
            health -= scriptMelee.degats;

            if(floatingTextPrefab && health > 0)
            {
                ShowFloatingTextMelee();
            }

            healthBarUI.SetActive(true);
            slider.value = CalculateHealth();

            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //anim.Play("EnemyHit");

        if (floatingTextPrefab && health > 0)
        {
            ShowFloatingTextGun();
        }

        healthBarUI.SetActive(true);
        slider.value = CalculateHealth();

        if (health <= 0)
        {
            Die();
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
        Gun scriptGun = FindObjectOfType<Gun>();
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + scriptGun.damage.ToString("F1");
    }

    void Die()
    {
        Death.Play();
        Destroy(gameObject);
        ScoreManager.instance.Addpoint(score);
    }
}

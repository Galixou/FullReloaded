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

    public GameObject healthBarUI;
    public Slider slider;

    //Animator anim;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
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
            Die();
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    void ShowFloatingTextGun()
    {
        Gun scriptGun = FindObjectOfType<Gun>();
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + scriptGun.damage.ToString("F1");
    }

    void Die()
    {
        Destroy(gameObject);
        ScoreManager.instance.Addpoint(score);
    }
}

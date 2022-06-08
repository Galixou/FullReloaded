using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private float health = 100f;
    private float maxHealth = 100f;

    public AudioSource Death;
    public AudioSource Melee;

    public MeleeAttack scriptMelee;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            Melee.Play();
            health -= scriptMelee.degats;
            healthBarUI.SetActive(true);
            slider.value = CalculateHealth();

            if (health <= 0)
            {
                Death.Play();
                Destroy(gameObject);
            }
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}

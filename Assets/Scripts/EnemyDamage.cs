using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    private float health = 100f;
    private float maxHealth = 100f;

    public AudioSource Death;
    public AudioSource Melee;

    public MeleeAttack scriptMelee;

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
        if (other.tag == "Melee")
        {
            Melee.Play();
            anim.Play("EnemyHit");
            health -= scriptMelee.degats;

            if(floatingTextPrefab && health > 0)
            {
                ShowFloatingText();
            }

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

    void ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-" + Mathf.Round(scriptMelee.degats * 10f) * 0.1f + " PV";
    }
}

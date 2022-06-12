using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.health;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (healthBar.fillAmount < 0.2f)
            healthBar.color = Color.red;
        else if (healthBar.fillAmount < 0.4f)
            healthBar.color = Color.yellow;
        else
            healthBar.color = Color.green;
    }
}

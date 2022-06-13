using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;

    public GameObject holster;
    public GameObject pauseMenu;
    public GameObject uiScreen;
    public GameObject deathScreen;
    Animator anim;

    MovementCharacter character;
    MouseLook mouse;

    public CanvasGroup ui;
    bool fadeOut;


    [HideInInspector]
    public bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<MovementCharacter>();
        mouse = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        if (health == 0)
        {
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(false);
            holster.SetActive(false);
            character.enabled = false;
            mouse.enabled = false;

            fadeOut = true;
            if (fadeOut)
            {
                if (ui.alpha >= 0)
                {
                    ui.alpha -= Time.deltaTime;
                    if (ui.alpha == 0)
                    {
                        fadeOut = false;
                        uiScreen.SetActive(false);
                    }
                }
            }

            anim.SetTrigger("death");
            isDead = true;
            deathScreen.SetActive(true);
        }
    }
}

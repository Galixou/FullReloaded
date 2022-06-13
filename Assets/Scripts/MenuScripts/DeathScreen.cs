using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Globalization;

public class DeathScreen : MonoBehaviour
{
    PlayerController player;

    CanvasGroup deathScreen;
    bool fadeIn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    ScoreManager scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        deathScreen = GetComponent<CanvasGroup>();
        scoreScript = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            fadeIn = true;
            if (fadeIn)
            {
                if (deathScreen.alpha < 1)
                {
                    deathScreen.alpha += Time.deltaTime;
                    if (deathScreen.alpha >= 1)
                    {
                        fadeIn = false;
                    }
                }
            }
        }

        scoreText.text = "SCORE: " + scoreScript.score.ToString("N0", CultureInfo.CreateSpecificCulture("fr-CA"));
        highscoreText.text = "HIGHSCORE: " + scoreScript.highScore.ToString("N0", CultureInfo.CreateSpecificCulture("fr-CA"));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

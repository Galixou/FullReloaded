using UnityEngine;
using TMPro;
using System.Globalization;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "SCORE: " + score.ToString("N0", CultureInfo.CreateSpecificCulture("fr-CA"));
        highscoreText.text = "HIGHSCORE: " + highScore.ToString("N0", CultureInfo.CreateSpecificCulture("fr-CA"));
    }

    public void Addpoint(int score)
    {
        this.score += score;
        scoreText.text = "SCORE: " + this.score.ToString("N0", CultureInfo.CreateSpecificCulture("fr-CA"));
        if (highScore < this.score)
            PlayerPrefs.SetInt("Highscore", this.score);
    }
}

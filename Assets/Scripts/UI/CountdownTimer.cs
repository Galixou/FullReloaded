using System.Collections;
using UnityEngine;
using TMPro;


public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI waveText;

    CanvasGroup fade;
    public GameObject transition;

    bool fadeOut;

    WaveSpawner waveInfo;

    // Use this for initialization
    void Start()
    {
        waveInfo = FindObjectOfType<WaveSpawner>();
        fade = GetComponent<CanvasGroup>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = waveInfo.waveCountdown.ToString("0");
        waveText.text = "Wave " + waveInfo.waveCount.ToString();

        if (waveInfo.waveCountdown <= 0)
        {
            fadeOut = true;
            if (fadeOut)
            {
                if (fade.alpha >= 0)
                {
                    fade.alpha -= Time.deltaTime;
                    if (fade.alpha == 0)
                    {
                        transition.SetActive(false);
                        fadeOut = false;
                    }
                }
            }
            currentTime = 0;
        }
    }
}

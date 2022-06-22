using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    public GameObject gm;
    public GameObject storyCanva;
    public GameObject ui;
    public GameObject holster;
    public TextMeshProUGUI storyText;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
        holster.SetActive(false);
        gm.SetActive(true);
        StartCoroutine(story());
    }

    IEnumerator story()
    {
        storyText.text = "Hey.";
        yield return new WaitForSeconds(2f);
        storyText.text = "You thought you could stay hidden for too long?";
        yield return new WaitForSeconds(3f);
        storyText.text = "Fool. Look at the windows to see who are welcoming you.";
        yield return new WaitForSeconds(3f);
        storyText.text = "Even if you didn't watch I will tell you.";
        yield return new WaitForSeconds(3f);
        storyText.text = "Military. And yeah. They found you once again.";
        yield return new WaitForSeconds(3f);
        storyText.text = "Not gonna lie. It's your end.";
        yield return new WaitForSeconds(3f);
        storyText.text = "Enjoy your fight and one last thing.";
        yield return new WaitForSeconds(3f);
        storyText.text = "Good death. Bye.";
        yield return new WaitForSeconds(2f);

        ui.SetActive(true);
        holster.SetActive(true);
        music.Stop();
        gm.SetActive(true);
        storyCanva.SetActive(false);
    }
}

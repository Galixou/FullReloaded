using UnityEngine;

public class FadeScript : MonoBehaviour
{
    CanvasGroup bloodImage;
    private bool fadeOut = false;

    private void Start()
    {
        bloodImage = GetComponent<CanvasGroup>();
    }

    public void Out()
    {
        bloodImage.alpha = 1;
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            bloodImage.alpha -= Time.deltaTime;
            if (bloodImage.alpha == 0)
            {
                fadeOut = false;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour
{
    public Light blueLight;
    public Light redLight;

    // Start is called before the first frame update
    void Start()
    {
        redLight.enabled = true;
        blueLight.enabled = false;
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        redLight.enabled = false;
        blueLight.enabled = true;

        yield return new WaitForSeconds(.25f);

        redLight.enabled = true;
        blueLight.enabled = false;

        yield return new WaitForSeconds(.25f);
        StartCoroutine(Blinking());
    }
}

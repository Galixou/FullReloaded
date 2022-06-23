using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    bool isFlickering = false;
    float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(.05f, .2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(.01f, .2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}

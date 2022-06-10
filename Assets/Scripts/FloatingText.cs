using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroytime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomIntensity = new Vector3(0.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroytime);

        transform.position += offset;
        transform.localPosition += new Vector3(Random.Range(-randomIntensity.x, randomIntensity.x),
                                               Random.Range(-randomIntensity.y, randomIntensity.y),
                                               Random.Range(-randomIntensity.z, randomIntensity.z));
    }
}

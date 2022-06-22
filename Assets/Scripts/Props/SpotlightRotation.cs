using UnityEngine;

public class SpotlightRotation : MonoBehaviour
{
    public Light heliSpotlight;
    public float searchSpeed;
    float currentAngle = 0f;

    float maxAngleLeft = -25f;
    float maxAngleRight = 41f;

    bool countUp;

    // Update is called once per frame
    void Update()
    {
        heliSpotlight.transform.Rotate(new Vector3(0, currentAngle * searchSpeed * Time.deltaTime, 0));

        if (currentAngle <= maxAngleLeft)
        {
            countUp = true;
        }

        if (currentAngle >= maxAngleRight)
        {
            countUp = false;
        }

        if (countUp)
        {
            currentAngle++;
        }

        if (!countUp)
        {
            currentAngle--;
        }
    }
}

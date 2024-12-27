using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public GameObject key;
    public float amplitude = 0.25f; // Half the total range for the sine wave
    public float frequency = Mathf.PI; // Frequency to achieve 1-second oscillation for the sine wave
    public float yOffset = 1f; // Center of the range (average of 0.5 and 1.5)
    public float rotationSpeed = 180f; // Full rotation (degrees) per second

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the Y position using a sine wave adjusted to range [0.5, 1.5]
        float yPosition = Mathf.Sin(Time.time * frequency) * amplitude + yOffset;

        // Update the key's position
        key.transform.position = new Vector3(key.transform.position.x, yPosition, key.transform.position.z);

        // Rotate the key on the X-axis by 360 degrees per second
        key.transform.rotation = Quaternion.Euler(0, Time.time * rotationSpeed, 90);
    }
}

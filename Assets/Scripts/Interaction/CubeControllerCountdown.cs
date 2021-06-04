using UnityEngine;

/**
 * Nicholas Cullmann - 4/2021
 * NewCharacterMovement - Shows a CubeController and activates it for a limited time.
 */

public class CubeControllerCountdown : MonoBehaviour
{
    public float maxTime = 5.0f;
    public GameObject[] controllers;
    public AudioSource tick;
    private float timer = 0.0f;
    private bool trigger = false;

    void Update()
    {
        // sets a timer and shows for the specified time
        if (trigger && timer < maxTime)
        {
            timer += Time.deltaTime;
            foreach (GameObject controller in controllers)
            {
                controller.SetActive(true);
            }
        }
        else if (timer > maxTime)
        {
            trigger = false;
            timer = 0.0f;
            foreach (GameObject controller in controllers)
            {
                controller.SetActive(false);
            }
            tick.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
        tick.Play();
    }
}

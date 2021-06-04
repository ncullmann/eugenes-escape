using UnityEngine;

/**
 * Nicholas Cullmann - 12/2020
 * RotateSky - Makes the skybox move.
 */

public class RotateSky : MonoBehaviour
{
    public float rotateSpeed = 0.2f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }
}

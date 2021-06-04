using UnityEngine;

/**
 * Nicholas Cullmann - 5/2021
 * NewCameraMovement - Handles the 3rd person camera.
 */

public class NewCameraMovement : MonoBehaviour
{
    public static float sensitivity = 0.5f;
    public GameObject player;
    private float maxZoom = 0.0f;

    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        float d = Input.GetAxis("Mouse ScrollWheel");

        // up/down with mouse 1
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(v, 0.0f, 0.0f);
        }
        else
        {
            player.transform.Rotate(0.0f, h * 10.0f * sensitivity, 0.0f);
        }

        // zoom in/out with mousewheel
        if (System.Math.Abs(maxZoom) < 2.0f)
        {
            transform.Translate(0.0f, -d / 2, d);
            maxZoom += d;
        }
        else
        {
            int zoomDirection = System.Math.Sign(maxZoom);
            transform.Translate(0.0f, zoomDirection * 0.1f * 0.5f, -zoomDirection * 0.1f);
            maxZoom = zoomDirection * 1.9f;
        }
    }

    // main menu sensitivity entry
    public void SetSensitivity(float sens)
    {
        sensitivity = sens;
    }
}

using UnityEngine;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 3/2021
 * FPSCounter - Display the current framerate.
 */

public class FPSCounter : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = "" + (1f / Time.deltaTime).ToString() + " FPS";
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Nicholas Cullmann - 6/2021
 * Credits - Shows the final scene for 5 seconds, then return to the menu.
 */

public class Credits : MonoBehaviour
{
    private float timer = 0.0f;

    void Update()
    {
        // 5 seconds
        if (timer > 5.0f)
        {
            SceneManager.LoadScene(0);
        }

        timer += Time.deltaTime;
    }
}

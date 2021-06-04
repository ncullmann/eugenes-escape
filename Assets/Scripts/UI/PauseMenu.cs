using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Nicholas Cullmann - 5/2021
 * PauseMenu - Handles pausing the game.
 */

public class PauseMenu : MonoBehaviour
{
    private static bool paused = false;
    public GameObject pauseUI;
    public string mainMenu;
    public NewCameraMovement cam;
    public GameObject sound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        sound.SetActive(true);
        cam.enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        paused = false;
    }

    private void Pause()
    {
        pauseUI.SetActive(true);
        sound.SetActive(false);
        cam.enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0.0f;
        paused = true;
    }

    public void Quit()
    {
        Resume();
        SceneManager.LoadScene(mainMenu);
    }
}

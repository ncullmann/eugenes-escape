using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Nicholas Cullmann - 5/2021
 * MainMenu - Controls the Panels of the main menu, and starts/quits the game.
 */

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string tutorialLevel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject controlsPanel;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(tutorialLevel);
    }

    public void OptionsMenu(bool back)
    {
        mainPanel.SetActive(back);
        optionsPanel.SetActive(!back);
    }

    public void ControlsMenu(bool back)
    {
        mainPanel.SetActive(back);
        controlsPanel.SetActive(!back);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}

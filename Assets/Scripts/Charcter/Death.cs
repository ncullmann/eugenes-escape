using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 1/2021
 * Death - Handles lives, respawning, and other map cleanup after the player dies.
 */

public class Death : MonoBehaviour
{
    private static int lives = 3;

    public GameObject livesText1;
    public GameObject livesText2;
    public CubeController[] cubeControllers;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string mainMenu;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            lives = 3;

        // HUD entry for lives
        livesText1.GetComponent<Text>().text = "x" + lives;
        livesText2.GetComponent<Text>().text = "x" + lives;
    }

    private void OnTriggerEnter()
    {
        lives--;
        // don't show "-1" before escaping to menu
        string livesStr = lives < 0 ? "0" : lives.ToString();
        livesText1.GetComponent<Text>().text = "x" + livesStr;
        livesText2.GetComponent<Text>().text = "x" + livesStr;
        player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();

        // reset cube controllers to clean up the map
        if (cubeControllers.Length > 0)
        {
            foreach (CubeController cc in cubeControllers)
                cc.SwitchCubes(false);
        }

        // game over :(
        if (lives < 0)
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    public void OnEnable()
    {
        livesText1.GetComponent<Text>().text = "x" + lives;
        livesText2.GetComponent<Text>().text = "x" + lives;
    }

    public void IncrementLives()
    {
        lives++;
    }

    public void EnableGodMode()
    {
        // godmode is 999 lives
        lives = lives == 3 ? 999 : 3;
    }

    public void ManualTrigger()
    {
        OnTriggerEnter();
    }
}

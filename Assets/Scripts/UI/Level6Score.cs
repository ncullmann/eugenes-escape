using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Nicholas Cullmann - 5/2021
 * Level6Score - Handles the score for Level 6.
 */


public class Level6Score : MonoBehaviour
{
    public GlobalScore score;
    public SimpleTimer timer;
    [SerializeField] private string finalLevel;

    void Update()
    {
        // restart without taking a life
        if (timer.timer < 0.1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // 12 rings
        if (score.GetScore() >= 12000)
        {
            SceneManager.LoadScene(finalLevel);
        }
    }
}

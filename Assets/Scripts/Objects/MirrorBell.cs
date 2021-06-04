using UnityEngine;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 1/2021
 * MirrorBell - Increases the score when a player collects a bell.
 *              When it is reenabled (player runs out of lives), 
 *              score resets to 0.
 * NOTE - Bells were scrapped in favor of secrets. This script is only used in Level 6.
 */

public class MirrorBell : MonoBehaviour
{
    private static int bellScore;
    public GameObject[] totalScoreText;
    public GameObject[] bellScoreText;
    public GlobalScore globalScore;
    public AudioSource coinSound;

    private void OnTriggerEnter()
    {
        bellScore++;

        // hidden bells are worth more
        if (gameObject.tag.Equals("HiddenObject"))
            globalScore.IncrementScore(5000);
        else
            globalScore.IncrementScore(1000);

        // update text
        foreach (GameObject bst in bellScoreText)
            bst.GetComponent<Text>().text = "" + bellScore;
        foreach (GameObject tst in totalScoreText)
            tst.GetComponent<Text>().text = "" + globalScore.GetScore();

        gameObject.SetActive(false);
        coinSound.Play();
    }


    public void OnEnable()
    {
        // when reenabled, reset score
        globalScore.ResetScore();
        bellScore = 0;
        foreach (GameObject bst in bellScoreText)
            bst.GetComponent<Text>().text = "0";
        foreach (GameObject tst in totalScoreText)
            tst.GetComponent<Text>().text = "0000";
    }
}

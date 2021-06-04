using UnityEngine;

/**
 * Nicholas Cullmann - 2/2021
 * GlobalScore - Keeps track of the score for all elements.
 */

public class GlobalScore : MonoBehaviour
{
    private int score;

    public int GetScore() { return score; }
    public void IncrementScore(int incrementation) { score += incrementation; }
    public void ResetScore() { score = 0; }

}

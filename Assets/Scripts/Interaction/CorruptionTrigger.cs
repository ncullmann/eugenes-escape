using UnityEngine;

/**
 * Nicholas Cullmann - 4/2021
 * CorruptionTrigger - Starts/ends movement reandomization on trigger.
 */

public class CorruptionTrigger : MonoBehaviour
{
    public GameObject player;
    public bool isBeginning = true;

    void OnTriggerEnter()
    {
        if (isBeginning)
        {
            player.GetComponent<MovementCorruption>().enabled = true;
        }
        else
        {
            player.GetComponent<MovementCorruption>().enabled = false;
        }

    }
}

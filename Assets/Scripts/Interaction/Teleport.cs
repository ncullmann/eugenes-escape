using UnityEngine;

/**
 * Nicholas Cullmann - 5/2021
 * Teleport - Teleports the player to a specified point on trigger.
 */

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = teleportPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}

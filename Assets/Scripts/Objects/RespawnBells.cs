using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * RespawnBells - Respawns the bells on the map after the player runs out of lives.
 * NOTE - Bells were scrapped in favor of secrets. This script is only used in Level 6.
 */

public class RespawnBells : MonoBehaviour
{
    public GameObject bells;
    private void OnEnable()
    {
        for (int i = 0; i < bells.transform.childCount; i++)
            bells.transform.GetChild(i).gameObject.SetActive(true);
    }
}

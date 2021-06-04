using UnityEngine;

/**
 * Nicholas Cullmann - 5/2021
 * SecretReward - Awards an extra life for a secret.
 */

public class SecretReward : MonoBehaviour
{
    public Death deathObj;
    public AudioSource collect;

    private void OnTriggerEnter(Collider other)
    {
        collect.Play();
        deathObj.IncrementLives();
        // update HUD text
        deathObj.enabled = false;
        deathObj.enabled = true;
        Destroy(gameObject);
    }
}

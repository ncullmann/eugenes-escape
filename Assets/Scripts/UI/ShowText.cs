using System.Collections;
using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * ShowText - Shows a bit of text after an event happens.
 */

public class ShowText : MonoBehaviour
{
    public GameObject text;
    private bool notActivated = true;
    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(notActivated);
        // removes after 3 seconds
        StartCoroutine(RemoveAfterSeconds(3, text));
        notActivated = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}

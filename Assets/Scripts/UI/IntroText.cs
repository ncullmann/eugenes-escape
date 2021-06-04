using UnityEngine;

/**
 * Nicholas Cullmann - 2/2021
 * IntroText - Shows a dialogue of sequential text.
 */

public class IntroText : MonoBehaviour
{
    private int textSequence = 0;
    public GameObject[] texts;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0.1f)
        {
            // once all clicked through, remove it
            if (textSequence >= texts.Length - 1)
            {
                gameObject.SetActive(false);
            }
            else
            {
                // continue in the sequence
                texts[textSequence].SetActive(false);
                textSequence++;
                texts[textSequence].SetActive(true);
            }
        }
    }
}

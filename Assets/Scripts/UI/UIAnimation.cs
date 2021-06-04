using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 5/2020
 * UIAnimation - Animates the main menu
 */

public class UIAnimation : MonoBehaviour
{
    public GameObject menuText;
    public GameObject menuText2;
    public GameObject[] robots;
    private string s;
    private int i;
    private float timer = 0.0f;

    void Start()
    {
        s = menuText.GetComponent<Text>().text;
        StartCoroutine(Wait());
    }

    // animates the 2D robot on the main menu
    void Update()
    {
        if (timer > 0.05f)
        {
            if (i == 0)
                robots[robots.Length - 1].SetActive(false);
            else
                robots[i - 1].SetActive(false);

            robots[i].SetActive(true);
            i++;
            i %= 17;
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }

    // colors in the text on the main menu
    IEnumerator Wait()
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s.Substring(i, 1).Equals("\n"))
                continue;

            menuText.GetComponent<Text>().text = s.Substring(0, i + 1);
            menuText2.GetComponent<Text>().text = s.Substring(0, i + 1);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

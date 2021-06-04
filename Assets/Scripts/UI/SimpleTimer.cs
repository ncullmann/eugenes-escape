using UnityEngine;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 12/2020
 * SimpleTimer - Shows a timer for the player. If time is up, the robot loses a life.
 */

public class SimpleTimer : MonoBehaviour
{
    public float timer = 200.0f;
    public float resetValue;
    public GameObject timer1;
    public GameObject timer2;
    public GameObject timer3;
    public Death deathObj;

    void Update()
    {
        timer -= Time.deltaTime;
        // no decimal points
        string s = timer.ToString().Substring(0, 3);
        if (timer < 100 && timer > 10)
            s = s.Substring(0, 2);

        timer1.GetComponent<Text>().text = s;
        timer2.GetComponent<Text>().text = s;
        timer3.GetComponent<Text>().text = s;

        if (timer < 0.0f)
        {
            deathObj.ManualTrigger();
            timer = resetValue;
        }
    }

    private void OnEnable()
    {
        timer = resetValue;
    }
}

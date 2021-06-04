using UnityEngine;

/**
 * Nicholas Cullmann - 2/2021
 * EnableObjectOnTrigger - Set an invisible wall as trigger to show a GameObject when passed.
 */

public class EnableObjectOnTrigger : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject[] disabledObjs;

    void OnTriggerEnter()
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in disabledObjs)
        {
            obj.SetActive(false);
        }
    }
}

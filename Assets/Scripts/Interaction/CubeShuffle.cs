using UnityEngine;

/**
 * Nicholas Cullmann - 3/2021
 * CubeShuffle - Randomizes a group of cubes slightly each tick.
 */

public class CubeShuffle : MonoBehaviour
{
    public float moveAfterSeconds = 1.0f;
    public GameObject[] cubeField;
    public float maxMovement = 1.0f;
    public bool xEnabled;
    public bool yEnabled;
    public bool zEnabled;


    void Start()
    {
        // one "tick" repeats moveAfterSeconds
        InvokeRepeating(nameof(ShuffleField), 0.0f, moveAfterSeconds);
    }

    void ShuffleField()
    {
        if (xEnabled)
        {
            foreach (GameObject cube in cubeField)
            {
                cube.transform.Translate(new Vector3(Random.Range(-maxMovement, maxMovement), 0.0f, 0.0f));
            }
        }
        if (yEnabled)
        {
            foreach (GameObject cube in cubeField)
            {
                cube.transform.Translate(new Vector3(0.0f, Random.Range(-maxMovement, maxMovement), 0.0f));
            }
        }
        if (zEnabled)
        {
            foreach (GameObject cube in cubeField)
            {
                cube.transform.Translate(new Vector3(0.0f, 0.0f, Random.Range(-maxMovement, maxMovement)));
            }
        }
    }
}

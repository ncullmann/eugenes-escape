using UnityEngine;

/**
 * Nicholas Cullmann - 5/2021
 * ResetCubefield - Resets the cubefield on death to avoid overspread.
 */

public class ResetCubefield : MonoBehaviour
{
    public GameObject[] cubes;
    private Vector3[] originalPosition;

    void Start()
    {
        originalPosition = new Vector3[cubes.Length];

        for (int i = 0; i < cubes.Length; i++)
        {
            originalPosition[i] = cubes[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // sets back to original position
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = originalPosition[i];
        }
    }
}

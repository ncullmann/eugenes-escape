using UnityEngine;

/**
 * Nicholas Cullmann - 4/2021
 * Movement Corruption - Randomizes the player's movement every tick.
 */

public class MovementCorruption : MonoBehaviour
{
    public GameObject player;
    public float tickRate = 0.5f;
    private CharacterController controller;
    private float timer = 0.0f;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // randomizes movement
        if (timer > tickRate)
        {
            controller.Move(new Vector3(Random.Range(-2.0f, 2.0f), 0.0f, Random.Range(-3.0f, 3.0f)));
            timer = 0.0f;
        }
    }
}

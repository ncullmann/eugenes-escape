using UnityEngine;

/**
 * Nicholas Cullmann - 4/2021
 * Boost - Launches the player on trigger.
 */

public class Boost : MonoBehaviour
{
    public GameObject player;
    private CharacterController controller;
    public float[] xyz = { 0.0f, 1.0f, 0.0f };      // set to zero for no boost (x, y (default), z)
    private bool trigger = false;
    private float timer = 0.0f;


    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        float b;

        if (trigger && timer < 1.0f)
        {
            timer += Time.deltaTime;
            b = timer * Time.deltaTime;
            controller.Move(new Vector3(xyz[0] * b, xyz[1] * b, xyz[2] * b));
        }
        // smooth descend
        else if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            b = timer * Time.deltaTime;
            controller.Move(new Vector3(xyz[0] * b, xyz[1] * b, xyz[2] * b));
            trigger = false;
        }
        else
        {
            timer = 0.0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
    }
}

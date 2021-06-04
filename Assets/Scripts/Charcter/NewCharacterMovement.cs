using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * NewCharacterMovement - New and improved movement for the robot.
 */

public class NewCharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpHeight = 4.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 airVector = Vector3.zero;
    private bool wasAirborne = false;
    private float timer = 0.0f;

    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            // skip an iteration to make character feel less slippery when landing
            if (!wasAirborne)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            wasAirborne = false;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += Mathf.Sqrt(jumpHeight * gravity);
                wasAirborne = true;
            }
            timer = 0.0f;
        }

        else
        {
            // gives the player midair control, half speed
            timer += Time.deltaTime;
            moveDirection.x *= 0.5f;
            moveDirection.z *= 0.5f;

            airVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            airVector = transform.TransformDirection(airVector);
            airVector *= speed;
            controller.Move(airVector * Time.deltaTime);

            /* this activates if the robot just barely touches the ground but is not considered "grounded".
               without, the player could narrowly miss out on a critical jump. */
            if (timer > 0.0001f && timer < 0.10f && Input.GetButtonDown("Jump"))
            {
                moveDirection.y += Mathf.Sqrt(jumpHeight * gravity);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

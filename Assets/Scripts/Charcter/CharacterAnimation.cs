using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * CharacterAnimation - Handles animations for the robot.
 */

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.StopPlayback();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float groundedVelocity = Input.GetAxis("Vertical");
            float turningVelocity = Input.GetAxis("Horizontal");

            if (System.Math.Abs(groundedVelocity) >= System.Math.Abs(turningVelocity))
            {
                if (groundedVelocity > 0.0f)
                    anim.Play("Walking");
                else if (groundedVelocity < 0.0f)
                    anim.Play("Walking Back");
                else
                    anim.Play("Idle");
            }
            else
            {
                if (turningVelocity > 0.0f)
                    anim.Play("Turning Right");
                else if (turningVelocity < 0.0f)
                    anim.Play("Turning Left");
                else
                    anim.Play("Idle");
            }
        }
        else
        {
            float airVelocity = controller.velocity.y;
            if (airVelocity > 1.0f)
                anim.Play("Jump");
            else if (airVelocity < -1.0f)
                anim.Play("Falling");
        }
    }
}

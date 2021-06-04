using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * PlatformRotate- Rotates a platform on the given axis.
 */

public class PlatformRotate : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject player;
    public enum RotationAxis { X, Y, Z };
    public RotationAxis axis;

    void Update()
    {
        switch (axis)
        {
            case RotationAxis.X:
                transform.Rotate(Time.deltaTime * speed, 0, 0);
                break;
            case RotationAxis.Y:
                transform.Rotate(0, Time.deltaTime * speed, 0);
                break;
            case RotationAxis.Z:
                transform.Rotate(0, 0, Time.deltaTime * speed);
                break;
            default:
                transform.Rotate(0, Time.deltaTime * speed, 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // let player rotate with platform
        player.transform.parent = gameObject.transform;
        transform.parent = collider.transform;
        Physics.SyncTransforms();
    }

    private void OnTriggerExit(Collider collider)
    {
        player.transform.parent = null;
        transform.parent = null;
    }
}

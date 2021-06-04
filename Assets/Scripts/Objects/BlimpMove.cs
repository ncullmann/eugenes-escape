using UnityEngine;

/**
 * Nicholas Cullmann - 1/2021
 * BlimpMove - Moves tutorial blimps. 
 * NOTE - Unused now.
 */


public class BlimpMove : MonoBehaviour
{
    public float speed = 1.0f;
    public int dimension;
    public bool forward = true;

    void Update()
    {
        float direction = forward ? 1.0f : -1.0f;
        switch (dimension)
        {
            case 1:
                transform.Translate(Time.deltaTime * speed * direction, 0, 0);
                break;
            case 2:
                transform.Translate(0, Time.deltaTime * speed * direction, 0);
                break;
            case 3:
                transform.Translate(0, 0, Time.deltaTime * speed * direction);
                break;
            default:
                transform.Translate(Time.deltaTime * speed * direction, 0, 0);
                break;
        }

    }

}

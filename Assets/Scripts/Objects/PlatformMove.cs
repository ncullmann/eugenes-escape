using UnityEngine;

/**
 * Nicholas Cullmann - 12/2020
 * PlatformMove - Moves a platform on a specified axis.
 */

public class PlatformMove : MonoBehaviour
{
    public enum Direction { X, Y, Z };
    public Direction direction;
    public float speed = 1.0f;
    public float timeToCycle = 2.0f;
    private float timer = 0.0f;
    private bool movingBack = false;
    public GameObject player;
    private float[] mDim = { 0.0f, 0.0f, 0.0f };

    void Update()
    {
        mDim[(int)direction] = 1.0f;
        float transition = Time.deltaTime * speed;

        if (timeToCycle - timer > 0.0f && !movingBack)
        {
            // lets it work with any dimension
            transform.Translate(mDim[0] * transition, mDim[1] * transition, mDim[2] * transition);
            timer += Time.deltaTime;

            if (timer >= timeToCycle)
                movingBack = true;
        }

        else if (movingBack)
        {
            transition *= -1.0f;
            transform.Translate(mDim[0] * transition, mDim[1] * transition, mDim[2] * transition);
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
                movingBack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // let player move with it
        if (other.CompareTag("Player"))
        {
            player.transform.parent = gameObject.transform;
            transform.parent = other.transform;
            Physics.SyncTransforms();
        }
    }

    void OnTriggerExit()
    {
        player.transform.parent = null;
        transform.parent = null;
    }

}

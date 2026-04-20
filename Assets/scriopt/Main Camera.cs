using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float offsetY = 2f;

    private float highestY;

    void Start()
    {
        highestY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float desiredY = target.position.y + offsetY;

        if (desiredY > highestY)
        {
            highestY = desiredY;
        }

        transform.position = new Vector3(0f, highestY, -10f);
    }
}
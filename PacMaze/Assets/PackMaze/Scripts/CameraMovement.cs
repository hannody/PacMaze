using UnityEngine;


[RequireComponent(typeof(Camera))]

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.06f;
    public Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            //transform.LookAt(target);
        }
    }

}

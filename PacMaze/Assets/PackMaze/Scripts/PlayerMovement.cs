 using UnityEngine;

// PlayerMovement script requires the Player's GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.useGravity = false;
        }
    }

    float d;

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 && v != 0)
        {
            // no diagnal movement
            v = 0;
        }

        Vector3 movement = new Vector3(h, 0.0f, v);

        rb.velocity = movement * speed;

        //rb.MovePosition(transform.position + transform.forward * dir * Time.deltaTime);
    }
}

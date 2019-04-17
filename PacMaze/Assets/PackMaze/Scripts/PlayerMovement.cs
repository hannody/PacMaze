 using UnityEngine;

// PlayerMovement script requires the Player's GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;
    private readonly float h_dir = 0;
    private readonly float v_dir = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.useGravity = false;
        }
    }

    

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            rb.velocity = Mathf.Sign(h) * Vector3.right * speed;
        }

        if (v != 0)
        {
            rb.velocity = Mathf.Sign(v) * Vector3.forward * speed;
        }
        //print(rb.velocity.magnitude);
    }
}

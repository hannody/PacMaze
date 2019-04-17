 using UnityEngine;


public enum PlayerMovementStyle
{
    PacMan_Style,
    FPS_Style,
}


// PlayerMovement script requires the Player's GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    public PlayerMovementStyle movement_style = PlayerMovementStyle.PacMan_Style;

    private Rigidbody rb;

    private readonly float h_dir = 0;

    private readonly float v_dir = 0;


  
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        switch(movement_style)
        {
            case PlayerMovementStyle.PacMan_Style:
                PacManMovement(h, v);
                break;
            case PlayerMovementStyle.FPS_Style:
                FPS_Movement(h, v);
                break;
        }
        //print(rb.velocity.magnitude);
    }


    private void PacManMovement(float h, float v)
    {
        if (h != 0)
        {
            rb.velocity = Mathf.Sign(h) * Vector3.right * speed;
        }

        if (v != 0)
        {
            rb.velocity = Mathf.Sign(v) * Vector3.forward * speed;
        }
    }

    private void FPS_Movement(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0.0f, v);

        rb.velocity = movement * speed;
    }
}

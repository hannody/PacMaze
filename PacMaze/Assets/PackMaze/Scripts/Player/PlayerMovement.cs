using UnityEngine;
using UnityEngine.AI;


public enum PlayerMovementStyle
{
    PacMan_Style,
    FPS_Style,
    Click_Move_to,
}


// PlayerMovement script requires the Player's GameObject to have a Rigidbody component, attach it to the player object.
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    public PlayerMovementStyle movement_style = PlayerMovementStyle.PacMan_Style;

    private Rigidbody rb;

    private readonly float h_dir = 0;

    private readonly float v_dir = 0;

    private Camera cam;

    private NavMeshAgent agent;

  
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        
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
            case PlayerMovementStyle.Click_Move_to:
                ClickMoveToPosStyle();
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
        rb.velocity = new Vector3(h, 0.0f, v) * speed;
    }
    private void ClickMoveToPosStyle()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

}

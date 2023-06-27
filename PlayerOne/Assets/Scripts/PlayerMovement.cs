using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    //Grounding
    private BoxCollider2D coll;

    // Looping when touching wall
    private float screenLeftEdge;
    private float screenRightEdge;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 4.5f;
    [SerializeField] private float edgePadding = 0.1f;

    private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        //mainCamera = Camera.main;
        //CalculateScreenEdges(); //wall looping
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the character is about to hit the left or right edge
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveSpeed * x, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //LoopOnWallCollision();

        if (x > 0 && !facingRight)
        {
            Flip();
            facingRight = true;
            Debug.Log("turn right");
        }
        else if (x < 0 && facingRight)
        {
            Flip();
            facingRight = false;
            Debug.Log("turn left");
        }



        PreventScreenEdgeCollision();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    /*    Looping when touching wall

        private void LoopOnWallCollision()
        {
            if (transform.position.x < screenLeftEdge)
            {
                transform.position = new Vector3(screenRightEdge, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > screenRightEdge)
            {
                transform.position = new Vector3(screenLeftEdge, transform.position.y, transform.position.z);
            }
        }
    */

    private void CalculateScreenEdges()
    {
        Vector3 screenLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        screenLeftEdge = screenLeft.x;
        screenRightEdge = screenRight.x;
    }

    private void PreventScreenEdgeCollision()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        float clampedX = Mathf.Clamp(viewportPosition.x, edgePadding, 1 - edgePadding);
        Vector3 clampedWorldPosition = Camera.main.ViewportToWorldPoint(new Vector3(clampedX, viewportPosition.y, viewportPosition.z));
        transform.position = clampedWorldPosition;
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}

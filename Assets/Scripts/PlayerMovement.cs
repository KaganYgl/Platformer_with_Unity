using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 300;

    private Animator animator;
    private Rigidbody2D rb;
    private float horizontalDirection;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Run();
        if(isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 6.5f);
            isJumping = false;
        }
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if( horizontalDirection == 1)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(horizontalDirection == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Run()
    {
        rb.velocity = new Vector2(horizontalDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetBool("Run", horizontalDirection != 0);
    }
}

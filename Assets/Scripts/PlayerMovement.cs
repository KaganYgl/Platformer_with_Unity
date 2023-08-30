using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 300;

    private Animator animator;
    private Rigidbody2D rb;
    private float horizontalDirection;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);

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

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 6.5f);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}

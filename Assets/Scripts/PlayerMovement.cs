using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 18f;

    [SerializeField] float runSpeed = 500f;

    float dirX;

    Rigidbody2D rb;

    BoxCollider2D collider2D;

    [SerializeField] LayerMask groundMask;

    SpriteRenderer spriteRenderer;

    Animator animator;

    private enum MovementtState { idle, run, jump, fall }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }

        HandleAnimation();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(dirX * runSpeed * Time.deltaTime, rb.linearVelocity.y, 0f);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0, Vector2.down, 0.1f, groundMask);
    }

    void HandleAnimation()
    {
        MovementtState State;

        if (dirX > 0)
        {
            spriteRenderer.flipX = false;
            State = MovementtState.run;
        }
        else if (dirX < 0)
        {
            spriteRenderer.flipX = true;
            State = MovementtState.run;
        }
        else
        {
            State = MovementtState.idle;
        }


        if (rb.linearVelocity.y > 0.1f)
        {
            State = MovementtState.jump;
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            State = MovementtState.fall;
        }

        animator.SetInteger("State", (int)State);
    }
}
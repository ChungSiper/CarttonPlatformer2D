using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer; 
    public Transform groundCheck;
    private bool isGrounded;
    private Animator animator;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimator();
    }
    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        if(moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void HandleJump()
    {
        
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    private void HandleAttack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void UpdateAnimator()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        animator.SetFloat("MoveSpeed", Mathf.Abs(moveX));  
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", !isGrounded && rb.linearVelocity.y > 0);

    }
}

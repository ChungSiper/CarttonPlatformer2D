using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class Player_1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private bool _isGrounded;
    private Animator _animator;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //HandleMovement();
        //HandleJump();
        //UpdateAnimator();
    }
    public void HandleMovement( CallbackContext ctx)
    {
        float moveX = ctx.ReadValue<float>();
        
        //float moveX = Input.GetAxis("Horizontal");
        //_rb.linearVelocity = new Vector2(moveX * moveSpeed , _rb.linearVelocity.y);
        //if (moveX > 0)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else if (moveX < 0)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }
    public void HandleJump()
    {

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimator()
    {
        bool isRunning = Mathf.Abs(_rb.linearVelocity.x) > 0.1f;
        bool isJumping = !_isGrounded;
        _animator.SetBool("isRunning", isRunning);
        _animator.SetBool("isJumping", isJumping);

    }
}

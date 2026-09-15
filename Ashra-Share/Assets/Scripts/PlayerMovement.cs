using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float WalkingSpeed = 5f;
    public float RunningSpeed = 9f;
    private float CurrentSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Vector2.zero;
        CurrentSpeed = WalkingSpeed;

        if (Keyboard.current.aKey.isPressed) moveDir += Vector2.left;
        if (Keyboard.current.dKey.isPressed) moveDir += Vector2.right;
        if (Keyboard.current.wKey.isPressed) moveDir += Vector2.up;
        if (Keyboard.current.sKey.isPressed) moveDir += Vector2.down;

        if (Keyboard.current.leftShiftKey.isPressed)
            CurrentSpeed = RunningSpeed;
        else
            CurrentSpeed = WalkingSpeed;

        moveDir = moveDir.normalized;

        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("isMoving", moveDir != Vector2.zero);  
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * CurrentSpeed * Time.fixedDeltaTime);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class movementTest : MonoBehaviour
{
//movement var
    public float moveSpeed = 4f;
    public float running = 9f;
    //private float currentSpeed;

    public float WalkingSpeed = 5f;
    public float RunningSpeed = 9f;
    private float CurrentSpeed;
    private Vector2 moveDir;

    private PlayerAttackUpdate attackScr;

    private Rigidbody2D rb;

//anim var
    Animator thisAnim;
    float lastX, lastY;

    void Start()
    {
        thisAnim = GetComponent<Animator>();
        attackScr = GetComponent<PlayerAttackUpdate>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        /*Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.position += rightMovement;
        transform.position += upMovement;

        UpdateAnimation(heading);*/

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

        UpdateAnimation(moveDir);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * CurrentSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimation(Vector3 dir) 
    {
        if (attackScr.isAttacking)
        {
            return;
        }

        if(dir.x == 0f && dir.y == 0f)
        {
            //if we are idle, execute idle anim
            thisAnim.SetFloat("DirX", lastX);
            thisAnim.SetFloat("DirY", lastY);
            thisAnim.SetBool("Movement", false);
        } 
        else 
        {
            
            thisAnim.SetFloat("DirX", dir.x);
            thisAnim.SetFloat("DirY", dir.y);

            //thisAnim.SetFloat("LastDirX", dir.x);
            //thisAnim.SetFloat("LastDirY", dir.y);

            lastX = dir.x;
            lastY = dir.y;

            thisAnim.SetBool("Movement", true);
        }

        
    }
}
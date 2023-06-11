using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
   [Header("Movement")]
   public float moveSpeed;
   public float groundDrag;
   public Transform orientation;

   float horizontalInput;
   float verticalInput;

   public float jumpForce;
   public float jumpCooldown;
   public float airMultiplier;
   bool readyToJump = true;

    [Header("Torch Control")]
    public bool isTorching;
    public GameObject torch;
    public AudioSource torchSound;

   Vector3 moveDirection;

   Rigidbody rb;
   [Header("KeyBind")]
   public KeyCode jumpKey = KeyCode.Space;

   [Header("Ground Check")]
   public float playerHeight;
   public LayerMask whatIsGround;
   public static bool grounded;


   private void Start()
   {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isTorching = true;
   }

   private void FixedUpdate()
   {
    movePlayer();
   }

   private void Update()
   {
    // turning torch on and off, this is crucial as there's a box collision to prevent enemy from doing any damage if the torch is active
    if(Input.GetKeyDown(KeyCode.E) && isTorching)
    {
        isTorching = false;
        torch.SetActive(false);
        torchSound.Stop();
        enemyScript.canBeDamaged = true;
    }
    else if (Input.GetKeyDown(KeyCode.E) && !isTorching)
    {
        isTorching = true;
        torch.SetActive(true);
        torchSound.Play();
        enemyScript.canBeDamaged = false;
    }
    // ground check
    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, whatIsGround);
    MyInput();
    speedControl();

    // Reduce movement speed when not on ground
    if(grounded)
    {
        rb.drag = groundDrag;
    }else
    {
        rb.drag = 0;
        moveSpeed = 5;
    }

   }

   private void MyInput()
   {
    // this is where you control the character with WASD, and jump with space
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
   }

   private void movePlayer()
   {
    moveDirection = orientation.forward * verticalInput + orientation.right*horizontalInput;
    if(grounded)
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }else if(!grounded)
    {
        rb.AddForce(moveDirection.normalized * moveSpeed *10f*airMultiplier, ForceMode.Force);
    }
    
   }

   private void speedControl()
   {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
   }

   private void jump()
   {
    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
   }

   private void resetJump()
   {
    readyToJump = true;
   }
}

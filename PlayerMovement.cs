using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator myAnim;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    [SerializeField] AudioClip JumpVoice;
    [SerializeField] AudioClip fireVoice;
    [SerializeField] AudioClip enemVoice;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float climbGravityScale = 0f;
    [SerializeField] float normalGravity = 8f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
    bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();    
    }

    void Update()
    { 
       if(!isAlive)
       {
        Invoke("die2",2f);
        return;
       }
        
       Run();
       FlipFace();   
       ClimbLadder();
       
       dieBomb();
       dieEnem();
       
    }
    void OnFire(InputValue value)
    {
        if (!isAlive) {return;}
        Instantiate(bullet, gun.position, transform.rotation);
        AudioSource.PlayClipAtPoint(fireVoice, Camera.main.transform.position);

    }
    void OnMove(InputValue value)
    {
        if(!isAlive) {return;} 
        moveInput = value.Get<Vector2>();
    }
    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = normalGravity;
            myAnim.SetBool("IsClimbing",false);
            return; 
        } 
        Vector2 climbVelocity = new Vector2 (rb.velocity.x, moveInput.y * climbSpeed);
        
        rb.velocity = climbVelocity;
        rb.gravityScale = climbGravityScale;
        bool playerFaceOnLadder = Mathf.Abs(rb.velocity.y) > 0;
        myAnim.SetBool("IsClimbing" , playerFaceOnLadder);
    }
    void OnJump(InputValue value)
    {
        if(!isAlive) {return;} 
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {return;}

        if(value.isPressed)
        {
            
            rb.velocity += new Vector2 (0f, jumpSpeed);
            AudioSource.PlayClipAtPoint(JumpVoice, Camera.main.transform.position);
        }
    }
    void Run()
    {
        Vector2 PlayerVelocity = new Vector2 (moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = PlayerVelocity;

        bool playerFace = Mathf.Abs(rb.velocity.x) > 0;
        myAnim.SetBool("IsRunning" , playerFace);
    }
    void FlipFace()
    {
        bool playerFace = Mathf.Abs(rb.velocity.x) > 0;
        if (playerFace)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x),1f);
        }
    }

    void dieBomb()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Bomb")))
        {
            
            myAnim.SetTrigger("Dying");   
            rb.velocity += new Vector2 (0f, jumpSpeed);
            this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            isAlive = false;
        }
    }
    void dieEnem()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            AudioSource.PlayClipAtPoint(enemVoice, Camera.main.transform.position);
            myAnim.SetTrigger("Dying");   
            rb.velocity += new Vector2 (0f, jumpSpeed);
            this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            isAlive = false;
        }
    }
    void die2()
    {    
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            isAlive = true;
    }
}



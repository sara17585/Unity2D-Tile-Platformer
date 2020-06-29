using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(26f, 25f);

    //State
    bool isAlive = true;


    //cached component refrences
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

   

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Running();
        FlipSide();
        Jumping();
        Climbing();
        Die();
    }

    private void Climbing()
    {
        if (!myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {

            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return; }

        float moveVertical = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, moveVertical * climbSpeed );
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
        

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);

    }

    private void Jumping()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }


        bool jump = Input.GetButtonDown("Jump");
        

        if (jump)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocity;
        }

        
    }

    private void Running()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveHorizontal*runSpeed, myRigidBody.velocity.y);

        myRigidBody.velocity = playerVelocity;


        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        
        
        
    }

    public void MovementSpeed(float currentSpeed)
    {
        runSpeed = currentSpeed;
    }


    private void FlipSide()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {

            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }

    }

    private void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            
            isAlive = false;
            myAnimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}

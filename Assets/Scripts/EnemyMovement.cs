using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 2f;


    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
   
   


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(runSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-runSpeed, 0f);
        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }

}

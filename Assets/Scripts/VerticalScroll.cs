using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    //Rigidbody2D myRigidBody;
    [Tooltip ("Game units per second")]
    [SerializeField] float speed =.05f;
    // Start is called before the first frame update
    //void Start()
    //{
    //    myRigidBody = GetComponent<Rigidbody2D>();
    //}

    // Update is called once per frame
    void Update()
    {
        float yMove = speed * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove ));
        //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y* speed);
    }
}

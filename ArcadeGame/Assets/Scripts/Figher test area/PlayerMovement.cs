using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerMovement : MonoBehaviour
{

    RaycastHit2D hit2d;

    public bool isGrounded;

    public float playerFallSpeed;
    public float playerSpeed;
    /*
    Ok, lets think about this, I was just gonna do normal rigid body stuff, but since this is a arcade game,
    I was thinking it would be better to implement our own, rough movement system, little to no acceleration,
    just constant movement.
    */
    void Update()
    {
        hit2d = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y,transform.position.z + 1), -transform.up,20f,3);
        if(hit2d.collider != null)
        {
            Debug.Log("Hit: " + hit2d.collider.name);
            //Arrggh, we hit land!
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        //Change these to the actual controller mapping later.
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + playerSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - playerSpeed, transform.position.y, transform.position.z);
        }

        if (!isGrounded)
        {
            Fall();
        }

    }

    private void JumpLerp()
    {
        //This is where we're going to put what a jump looks like.
    }

    private void Fall()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - playerFallSpeed, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    CharacterController character;
    public Vector3 moveDirection = Vector3.zero;
    public int frameJumpLatency;
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    int jumpCount = 0;
    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update() {

        if (character.isGrounded) {
            jumpCount=0;
            frameJumpLatency = 0;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount++;
                moveDirection.y = jumpSpeed;
            }
        }
        else if (frameJumpLatency < 10 && jumpCount==0)
        {
            frameJumpLatency++;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount++;
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            jumpCount++;
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    CharacterController character;
    private Vector3 moveDirection = Vector3.zero;

    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update() {
        
        
        if (character.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        if (!character.isGrounded) 
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    bool canJump = true;
    public float jumpForce=250;
	void FixedUpdate () {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            jump();
        }
	}

    void jump()
    {
        if (canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            canJump=true;
        }
    }
}

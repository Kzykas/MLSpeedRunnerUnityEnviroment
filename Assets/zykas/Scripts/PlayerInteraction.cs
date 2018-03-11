using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    PlayerMovement playerMovement;
    public float slowSpeed = 5f;
    public float slowDuration = 2.0f;
    float normalSpeed;

    void Start () {
        playerMovement = GetComponent<PlayerMovement>();
        normalSpeed = playerMovement.speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            Destroy(gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if(hit.collider.tag == "obstacle")
        {
            Destroy(hit.gameObject);
            StartCoroutine(slowTimeDuration());
        }
    }


    IEnumerator slowTimeDuration()
    {
        playerMovement.speed = slowSpeed;
        yield return new WaitForSeconds( slowDuration);
        playerMovement.speed = normalSpeed;
    }
}

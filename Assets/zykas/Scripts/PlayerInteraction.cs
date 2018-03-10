using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    PlayerMovement playerMovement;
    public float slowDuration = 5f;

    void Start () {
        playerMovement = GetComponent<PlayerMovement>();
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
        float tempSpeed = playerMovement.speed;
        playerMovement.speed = slowDuration;
        yield return new WaitForSeconds( 2.0f);
        playerMovement.speed = tempSpeed;
    }
}

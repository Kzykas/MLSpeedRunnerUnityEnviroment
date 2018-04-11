using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {
    CharacterController charCon;
    public CharacterController otherPlayer;

	// Use this for initialization
	void Start () {
        charCon = this.GetComponent<CharacterController>();
        Physics.IgnoreLayerCollision(8, 8);
    }
	
	// Update is called once per frame
	void Update () {
        //Physics.IgnoreCollision(charCon, otherPlayer.GetComponent<CharacterController>());
    }
}

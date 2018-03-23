using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceLinkUpdate : MonoBehaviour {

    public NavMeshLink navMeshLink;
	// Use this for initialization
	void Start () {
        navMeshLink = transform.GetComponent<NavMeshLink>();

        InvokeRepeating("ForcePosUpdate", 0.5f, 0.5f);
	}

    void ForcePosUpdate()
    {
        navMeshLink.startPoint = navMeshLink.startPoint - new Vector3(0.1f, 0.1f, 0.1f);
        navMeshLink.startPoint = navMeshLink.startPoint + new Vector3(0.1f, 0.1f, 0.1f);
    }
}

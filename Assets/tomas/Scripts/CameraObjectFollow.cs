using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollow : MonoBehaviour {

    public float cameraOffsetZ = 10.0f;
    Vector3 centerOfVectors;
    List<GameObject> players = new List<GameObject>();

    void Start () {
        players.Add(GameObject.Find("player1"));
        if(GameObject.Find("player2") != null)
        {
            players.Add(GameObject.Find("player2"));
        }
        if (GameObject.Find("player3") != null)
        {
            players.Add(GameObject.Find("player3"));
        }
        if (GameObject.Find("player4") != null)
        {
            players.Add(GameObject.Find("player4"));
        }
    }
	
	void Update () {
        centerOfVectors = CenterOfVectors(players);
        transform.position = centerOfVectors + new Vector3(0, 0, cameraOffsetZ*(-1));
    }

    public Vector3 CenterOfVectors(List<GameObject> objects)
    {
        Vector3 sum = Vector3.zero;
        if (objects == null || objects.Count == 0)
        {
            return sum;
        }

        foreach (GameObject vec in objects)
        {
            sum += vec.transform.position;
        }
        return sum / objects.Count;
    }
}

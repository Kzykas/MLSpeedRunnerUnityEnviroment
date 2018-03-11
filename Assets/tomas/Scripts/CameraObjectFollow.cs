using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollow : MonoBehaviour {
    public float maxZoomDistance = 30.0f;
    public float maxLastTileDistance = 30.0f;
    private float cameraOffsetZ = 10.0f;
    float greatestDistance;
    float aspectRatio;
    float tanFov;
    Vector3 centerOfVectors;
    List<GameObject> players = new List<GameObject>();

    WorldGeneration worldGeneration;
    GameObject generationObject;

    void Start () {
        generationObject = GameObject.FindGameObjectWithTag("MainGenerator");
        worldGeneration = generationObject.GetComponent<WorldGeneration>();

        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
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
        aspectRatio = Screen.width / Screen.height;
        greatestDistance = Distance(players, players.Count-1);
        centerOfVectors = CenterOfVectors(players);

        cameraOffsetZ = (greatestDistance / 2 / aspectRatio) / tanFov;

        if(centerOfVectors.x + maxLastTileDistance*(-1) >= worldGeneration.tileClone[0].transform.position.x)
        {
            if (cameraOffsetZ <= maxZoomDistance)
                transform.position = centerOfVectors + new Vector3(0, 0, cameraOffsetZ * (-1));
            else
                transform.position = centerOfVectors + new Vector3(0, 0, maxZoomDistance * (-1));
        }
        else
        {
            if (cameraOffsetZ <= maxZoomDistance)
                transform.position = new Vector3(transform.position.x, centerOfVectors.y, cameraOffsetZ * (-1));
            else
                transform.position = new Vector3(transform.position.x, centerOfVectors.y, maxZoomDistance * (-1));
        }

    }

    float Distance(List<GameObject> objects, int index)
    {
        List<float> distances = new List<float>();
        foreach (GameObject obj in objects)
        {
            float dist = Vector3.Distance(gameObject.transform.position, obj.transform.position);
            distances.Add(dist);
        }

        distances.Sort();

        return distances[index];
    }

    Vector3 CenterOfVectors(List<GameObject> objects)
    {
        Vector3 sum = Vector3.zero;
        for (int i = 0; i < objects.Count; i++)
        {
            sum += objects[i].transform.position;
        }
        return sum / objects.Count;
    }
}

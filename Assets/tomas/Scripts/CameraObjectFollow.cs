using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollow : MonoBehaviour {
    public float maxZoomOutDistance = 30.0f;
    public float maxZoomInDistance = 10.0f;
    public float maxLastTileDistance = 30.0f;
    public Vector3 cameraStaticPosition;
    private float cameraOffsetZ = 10.0f;
    float greatestDistance;
    float aspectRatio;
    float tanFov;
    Vector3 centerOfVectors;
    List<GameObject> players = new List<GameObject>();
    float minVector;
    float maxVector;

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
        CenterOfVectors(players);
        centerOfVectors.x = (minVector + maxVector) / 2;
        Debug.Log("min x is: " + minVector + ", max x is: " + maxVector);
        cameraOffsetZ = ((greatestDistance + cameraStaticPosition.x) / 2 / aspectRatio) / tanFov;

        if(centerOfVectors.x + maxLastTileDistance*(-1) >= worldGeneration.tileClone[0].transform.position.x)
        {
            if (cameraOffsetZ <= maxZoomOutDistance)
                transform.position = cameraStaticPosition + new Vector3(centerOfVectors.x, 0, cameraOffsetZ * (-1));
            else
                transform.position = cameraStaticPosition + new Vector3(centerOfVectors.x, 0, maxZoomOutDistance * (-1));

            if (cameraOffsetZ <= maxZoomInDistance)
                transform.position = cameraStaticPosition + new Vector3(centerOfVectors.x, 0, maxZoomInDistance * (-1));
        }
        else
        {
            if (cameraOffsetZ <= maxZoomOutDistance)
                transform.position = new Vector3(transform.position.x, transform.position.y, cameraOffsetZ * (-1));
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZoomOutDistance * (-1));
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

    void CenterOfVectors(List<GameObject> objects)
    {
        minVector = Mathf.Infinity;
        maxVector = -9999.0f;
        for (int i = 0; i < objects.Count; i++)
        {
            minVector = (objects[i].transform.position.x < minVector) ? objects[i].transform.position.x : minVector;
            maxVector = (objects[i].transform.position.x > maxVector) ? objects[i].transform.position.x : maxVector;
        }
    }
}

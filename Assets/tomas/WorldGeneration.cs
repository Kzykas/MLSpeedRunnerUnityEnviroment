using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject ground;
    private GameObject lastTile;

    public float posOffsetX = -40.0f;
    private Vector3 pos;

    private GameObject mainPlayer;
    public int tileGenerationAmount = 15;
    public List<GameObject> tileClone = new List<GameObject>();
    private int currId = 0;
    public float posToGenerateFrom = 5.0f;
    private float groundSizeX;

    void Awake () {
        //Find main player, FUTURE CHANGES: find all players
        mainPlayer = GameObject.FindGameObjectWithTag("Player");

        //Find the size of the ground
        Mesh mesh = ground.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;
        groundSizeX = mesh.bounds.size.x * ground.transform.localScale.x;
        
        //Generate the base ground
        pos = new Vector3(posOffsetX, 0, 0);
        for(int i = 0; i < tileGenerationAmount; i++)
        {
            GameObject clone;
            clone = Instantiate(ground, pos, Quaternion.identity) as GameObject;
            tileClone.Add(clone);
            currId++;
            posOffsetX += groundSizeX;
            pos = new Vector3(posOffsetX, 0, 0);
        }
        
	}
	
	void Update () {
        //Generate further tiles
		if(mainPlayer.transform.position.x > posToGenerateFrom)
        {
            GameObject clone;
            clone = Instantiate(ground, pos, Quaternion.identity) as GameObject;
            tileClone.Add(clone);
            currId++;
            posToGenerateFrom += groundSizeX;
            posOffsetX += groundSizeX;
            pos = new Vector3(posOffsetX, 0, 0);

            //Delete previous tiles
            Destroy(tileClone[0].gameObject);
            tileClone.RemoveAt(0);
        }


    }
}

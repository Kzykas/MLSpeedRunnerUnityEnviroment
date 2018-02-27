using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject ground;
    private GameObject lastTile;

    public float posOffsetX = -20.0f;
    private Vector3 pos;

    private GameObject mainPlayer;

    public int generationFurther = 3;
    public float posToGenerateFrom = 5.0f;
    private float groundSizeX;

    /*private Camera mainCamera;
    public Vector2 widthThresold;
    public Vector2 heightThresold;*/

    void Awake () {
        //Find main player, FUTURE CHANGES: find all players
        mainPlayer = GameObject.FindGameObjectWithTag("Player");

        //Find the size of the ground
        Mesh mesh = ground.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;
        groundSizeX = mesh.bounds.size.x * ground.transform.localScale.x;
        

        //Generate the base ground
        pos = new Vector3(posOffsetX, 0, 0);
        for(int i = 0; i < generationFurther; i++)
        {
            GameObject clone;
            clone = Instantiate(ground, pos, Quaternion.identity) as GameObject;
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
            posToGenerateFrom += groundSizeX;
            posOffsetX += groundSizeX;
            pos = new Vector3(posOffsetX, 0, 0);


            
        }
        //Delete previous tiles
        /*Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
            Destroy(gameObject);*/
    }
}

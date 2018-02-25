using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject ground;
    private float posIncreaseX = 10.0f;
    public float currPosX = -20.0f;
    private Vector3 pos;

    public int generationFurther = 3;

    void Start () {
        pos = new Vector3(currPosX, 0, 0);
        for(int i = 0; i < generationFurther; i++)
        {
            GameObject clone;
            clone = Instantiate(ground, pos, Quaternion.identity) as GameObject;
            currPosX += posIncreaseX;
            pos = new Vector3(currPosX, 0, 0);
        }
        
	}
	
	void Update () {
		
	}
}
